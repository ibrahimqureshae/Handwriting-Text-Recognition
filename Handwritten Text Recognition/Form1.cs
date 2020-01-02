using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace handwritten_text_recognition
{


    public partial class Form1 : Form
    {
        private string result; // response is saved here
        Point lastPoint = Point.Empty;//Point.Empty represents null for a Point object
        bool drawMode = new Boolean();
        bool isMouseDown = new Boolean();


        // Add your Computer Vision subscription key and endpoint to your environment variables.
        static string subscriptionKey = Environment.GetEnvironmentVariable("COMPUTER_VISION_SUBSCRIPTION_KEY");
        static string endpoint = Environment.GetEnvironmentVariable("COMPUTER_VISION_ENDPOINT");

        // the Batch Read method endpoint
        static string uriBase = endpoint + "vision/v2.1/read/core/asyncBatchAnalyze";

        static byte[] GetImageAsByteArray(string imageFilePath)
        {
            // Open a read-only file stream for the specified file.
            using (FileStream fileStream =
                new FileStream(imageFilePath, FileMode.Open, FileAccess.Read))
            {
                // Read the file's contents into a byte array.
                BinaryReader binaryReader = new BinaryReader(fileStream);
                return binaryReader.ReadBytes((int)fileStream.Length);
            }
        }
        public async Task ReadText(string imageFilePath)
        {
            try
            {
                HttpClient client = new HttpClient();

                // Request headers.
                client.DefaultRequestHeaders.Add(
                    "Ocp-Apim-Subscription-Key", subscriptionKey);

                // Assemble the URI for the REST API method.
                string uri = uriBase;

                HttpResponseMessage response;

                // Two REST API methods are required to extract text.
                // One method to submit the image for processing, the other method
                // to retrieve the text found in the image.

                // operationLocation stores the URI of the second REST API method,
                // returned by the first REST API method.
                string operationLocation;

                // Reads the contents of the specified local image
                // into a byte array.
                byte[] byteData = GetImageAsByteArray(imageFilePath);

                // Adds the byte array as an octet stream to the request body.
                using (ByteArrayContent content = new ByteArrayContent(byteData))
                {
                    // This example uses the "application/octet-stream" content type.
                    // The other content types you can use are "application/json"
                    // and "multipart/form-data".
                    content.Headers.ContentType =
                        new MediaTypeHeaderValue("application/octet-stream");

                    // The first REST API method, Batch Read, starts
                    // the async process to analyze the written text in the image.
                    response = await client.PostAsync(uri, content).ConfigureAwait(false);
                }

                // The response header for the Batch Read method contains the URI
                // of the second method, Read Operation Result, which
                // returns the results of the process in the response body.
                // The Batch Read operation does not return anything in the response body.
                if (response.IsSuccessStatusCode)
                    operationLocation =
                        response.Headers.GetValues("Operation-Location").FirstOrDefault();
                else
                {
                    // Display the JSON error data.
                    string errorString = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("\n\nResponse:\n{0}\n",
                        JToken.Parse(errorString).ToString());
                    return;
                }

                // If the first REST API method completes successfully, the second 
                // REST API method retrieves the text written in the image.
                //
                // Note: The response may not be immediately available. Text
                // recognition is an asynchronous operation that can take a variable
                // amount of time depending on the length of the text.
                // You may need to wait or retry this operation.
                //
                // This example checks once per second for ten seconds.
                string contentString;
                int i = 0;
                do
                {
                    System.Threading.Thread.Sleep(1000);
                    response = await client.GetAsync(operationLocation).ConfigureAwait(false);
                    contentString = await response.Content.ReadAsStringAsync();
                    ++i;
                }
                while (i < 10 && contentString.IndexOf("\"status\":\"Succeeded\"") == -1);

                if (i == 10 && contentString.IndexOf("\"status\":\"Succeeded\"") == -1)
                {
                    Console.WriteLine("\nTimeout error.\n");
                    return;
                }


                Responsee obj = JsonConvert.DeserializeObject<Responsee>(contentString);
                var textRecognitionLocalFileResults = obj.recognitionResults;
                result = "";
                int lineNo = 1;
                foreach (Recognitionresult recResult in textRecognitionLocalFileResults)
                {
                    foreach (Line line in recResult.lines)
                    {
                        
                        Console.WriteLine(line.text);
                        result +=  line.text + "\r\n";
                        lineNo++;
                    }


                }



                

              
            }
            catch (Exception e)
            {
                Console.WriteLine("\n" + e.Message);
            }
        }
        public Form1()
        {
            result = "";

            drawMode = false;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            drawingModeLabel.Visible = false;
            imageModeLabel.Visible = true;// changes image label back to default
            Cursor = Cursors.Default; // changes cursor back to default.

            //hide draw mode buttons
            drawModeRecognizeButton.Visible = false;
            ClearButton.Visible = false;
            recognizeTextButtonLabel.Visible = false;
            clearButtonLabel.Visible = false;
            //hide draw mode buttons
            resultTextBox.Clear(); // clears the textBox for another incoming picture
            drawMode = false; // disables the draw mode
            string imageFilePath = "";
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Bitmap obj = new Bitmap(ofd.FileName);
                imageBox.SizeMode = PictureBoxSizeMode.StretchImage;
                imageBox.Image = (Image)obj;
                imageFilePath = ofd.FileName;
            }

            
            

            if (File.Exists(imageFilePath))
            {
                // Call the REST API method.
                
                ReadText(imageFilePath).Wait();
                resultTextBox.Text = result;

                //SetTextboxTextSafe(result);
            }
            else
            {
                MessageBox.Show("Invalid Image Path", "Path Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            

        }

       



       

        private void copyButton_click(object sender, EventArgs e)
        {
            if(resultTextBox.Text != "")
            {

                Clipboard.SetText(resultTextBox.Text);
            }
            else
            {
                MessageBox.Show("Please Load or Draw Image First", "No Text", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void saveButton_click(object sender, EventArgs e)
        {

            saveFileDialog1.Filter = "Text File | *.txt";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)

            {

                StreamWriter writer = new StreamWriter(saveFileDialog1.OpenFile());

               

                    writer.WriteLine(resultTextBox.Text);

                

                writer.Dispose();

                writer.Close();

            }



        }

        private void drawMode_click(object sender, EventArgs e)
        {
            drawingModeLabel.Visible = true;
            imageModeLabel.Visible = false;
            Cursor = Cursors.Hand;
            drawModeRecognizeButton.Visible = true;
            ClearButton.Visible = true;
            recognizeTextButtonLabel.Visible = true;
            clearButtonLabel.Visible = true;
            imageBox.Image = (handwritten_text_recognition.Properties.Resources.asd);




            
            resultTextBox.Clear();
            //pictureBox1.Image = null;
            drawMode = true;
            if (imageBox.Image == null)//if no available bitmap exists on the picturebox to draw on

            {
                //create a new bitmap
                Bitmap bmp = new Bitmap(imageBox.Width, imageBox.Height);

                imageBox.Image = bmp; //assign the picturebox.Image property to the bitmap created

            }








        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (drawMode == true)
            {

            lastPoint = e.Location;//we assign the lastPoint to the current mouse position: e.Location ('e' is from the MouseEventArgs passed into the MouseDown event)

            isMouseDown = true;//we set to true because our mouse button is down (clicked)
            }


        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown == true)//check to see if the mouse button is down

            {

                if (lastPoint != null)//if our last point is not null, which in this case we have assigned above

                {

                    if (imageBox.Image == null)//if no available bitmap exists on the picturebox to draw on

                    {
                        //create a new bitmap
                        Bitmap bmp = new Bitmap(imageBox.Width, imageBox.Height);

                        imageBox.Image = bmp; //assign the picturebox.Image property to the bitmap created

                    }

                    using (Graphics g = Graphics.FromImage(imageBox.Image))

                    {//we need to create a Graphics object to draw on the picture box, its our main tool

                        //when making a Pen object, you can just give it color only or give it color and pen size

                        g.DrawLine(new Pen(Color.Black, 2), lastPoint, e.Location);
                        g.SmoothingMode = SmoothingMode.AntiAlias;
                        //this is to give the drawing a more smoother, less sharper look

                    }

                    imageBox.Invalidate();//refreshes the picturebox

                    lastPoint = e.Location;//keep assigning the lastPoint to the current mouse position

                }

            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {

            if(drawMode == true)
            {


            isMouseDown = false;

            lastPoint = Point.Empty;
            }
        }

        private void drawModeRecognizeButton_click(object sender, EventArgs e)
        {
            string tempPath = Path.GetTempPath();
            tempPath = tempPath + "file.jpeg"; // gets temp folder path to save the drawing and then process it

            
            imageBox.Image.Save(tempPath);


            string imageFilePath = tempPath;

            
                
                

            


            if (File.Exists(imageFilePath))
            {
                // Call the REST API method.
                
                ReadText(imageFilePath).Wait();
                resultTextBox.Text = result;

                //SetTextboxTextSafe(result);
            }
            else
            {
                MessageBox.Show("Invalid Image Path", "Path Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            imageBox.Image = (handwritten_text_recognition.Properties.Resources.asd);
        }
    }
}
