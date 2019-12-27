using Emgu.CV;
using Emgu.CV.Structure;
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


namespace handwritten_text_recognition
{


    public partial class Form1 : Form
    {
        private string result;

       

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



                

                //// Display the JSON response.
                //Console.WriteLine("\nResponse:\n\n{0}\n",
                //    JToken.Parse(contentString).ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine("\n" + e.Message);
            }
        }
        public Form1()
        {
            result = "";
            

            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            string imageFilePath = "";
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Bitmap obj = new Bitmap(ofd.FileName);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox1.Image = (Image)obj;
                //imgInput = new Image<Bgr, byte>(ofd.FileName);
                //pictureBox1.Image = imgInput.Bitmap;
                imageFilePath = ofd.FileName;
            }

            // Get the path and filename to process from the user.
            Console.WriteLine("Text Recognition:");
            Console.Write("Enter the path to an image with text you wish to read: ");
            

            if (File.Exists(imageFilePath))
            {
                // Call the REST API method.
                Console.WriteLine("\nWait a moment for the results to appear.\n");
                ReadText(imageFilePath).Wait();
                resultTextBox.Text = result;
                //SetTextboxTextSafe(result);
            }
            else
            {
                Console.WriteLine("\nInvalid file path");
            }
            Console.WriteLine("\nPress Enter to exit...");
            Console.ReadLine();


        }

       //public  void SetTextboxTextSafe(string result)
       // {
            
       //    resultLabel.Text = result.ToString();
       // }




        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        private void copyButton_click(object sender, EventArgs e)
        {
            Clipboard.SetText(resultTextBox.Text);
        }

        private void saveButton_click(object sender, EventArgs e)
        {

        }
    }
}
