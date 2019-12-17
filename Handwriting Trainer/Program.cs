using System;
using System.IO;
using System.Linq;
using Microsoft.ML;
using Microsoft.ML.Data;
using Microsoft.ML.Transforms;
using BetterConsoleTables;

namespace Handwriting_Trainer
{

    //It represents one digit
    class Digit
    {
        [ColumnName("PixelValues")]
        [VectorType(784)]
        public float[] PixelValues;

        [LoadColumn(0)]
        public float Number;
    }


    class DigitPrediction
    {
        [ColumnName("Score")]
        public float[] Score;
    }



    class Program
    {

        //dataset location

        private static string trainDataPath = @"F:\Project Data\emnist\emnist-balanced-train.csv";
        private static string testDataPath = @"F:\Project Data\emnist\emnist-balanced-test.csv";


        static void Main(string[] args)
        {

            // create a machine learning context
            var context = new MLContext();

            // load data
            Console.WriteLine("Loading data....");
            var columnDef = new TextLoader.Column[]
            {
            new TextLoader.Column(nameof(Digit.PixelValues), DataKind.Single, 1, 784),
            new TextLoader.Column("Number", DataKind.Single, 0)
            };
            var trainDataView = context.Data.LoadFromTextFile(
                path: trainDataPath,
                columns: columnDef,
                hasHeader: true,
                separatorChar: ',');
            var testDataView = context.Data.LoadFromTextFile(
                path: testDataPath,
                columns: columnDef,
                hasHeader: true,
                separatorChar: ',');

            var pipeline = context.Transforms.Conversion.MapValueToKey(
    outputColumnName: "Label",
    inputColumnName: "Number",
    keyOrdinality: ValueToKeyMappingEstimator.KeyOrdinality.ByValue)

    // step 2: concatenate all feature columns
    .Append(context.Transforms.Concatenate(
        "Features",
        nameof(Digit.PixelValues)))

    // step 3: cache data to speed up training                
    .AppendCacheCheckpoint(context)

    // step 4: train the model with SDCA
    .Append(context.MulticlassClassification.Trainers.SdcaMaximumEntropy(
        labelColumnName: "Label",
        featureColumnName: "Features"))

    // step 5: map the label key value back to a number
    .Append(context.Transforms.Conversion.MapKeyToValue(
        outputColumnName: "Number",
        inputColumnName: "Label"));

            // train the model
            Console.WriteLine("Training model....");
            var model = pipeline.Fit(trainDataView);



            // use the model to make predictions on the test data
            Console.WriteLine("Evaluating model....");
            var predictions = model.Transform(testDataView);

            // evaluate the predictions
            var metrics = context.MulticlassClassification.Evaluate(
                data: predictions,
                labelColumnName: "Number",
                scoreColumnName: "Score");

            // show evaluation metrics
            Console.WriteLine($"Evaluation metrics");
            Console.WriteLine($"    MicroAccuracy:    {metrics.MicroAccuracy:0.###}");
            Console.WriteLine($"    MacroAccuracy:    {metrics.MacroAccuracy:0.###}");
            Console.WriteLine($"    LogLoss:          {metrics.LogLoss:#.###}");
            Console.WriteLine($"    LogLossReduction: {metrics.LogLossReduction:#.###}");
            Console.WriteLine();



            // grab three digits from the test data
            var digits = context.Data.CreateEnumerable<Digit>(testDataView, reuseRowObject: false).ToArray();
            var testDigits = new Digit[] { digits[0], digits[1], digits[2], digits[3], digits[4] };

            // create a prediction engine
            var engine = context.Model.CreatePredictionEngine<Digit, DigitPrediction>(model);

            
                context.Model.Save(model, trainDataView.Schema, "Model.zip");
            



            // set up a table to show the predictions
            var table = new Table(TableConfiguration.Unicode());
            table.AddColumn("Digit");
            for (var i = 0; i < 47; i++)
                table.AddColumn($"P{i}");

            // predict each test digit
            for (var i = 0; i < testDigits.Length; i++)
            {
                var prediction = engine.Predict(testDigits[i]);

                table.AddRow(
                    testDigits[i].Number,
                    prediction.Score[0].ToString("P2"),
                    prediction.Score[1].ToString("P2"),
                    prediction.Score[2].ToString("P2"),
                    prediction.Score[3].ToString("P2"),
                    prediction.Score[4].ToString("P2"),
                    prediction.Score[5].ToString("P2"),
                    prediction.Score[6].ToString("P2"),
                    prediction.Score[7].ToString("P2"),
                    prediction.Score[8].ToString("P2"),
                    prediction.Score[9].ToString("P2"),
                    prediction.Score[10].ToString("P2"),
                    prediction.Score[11].ToString("P2"),
            prediction.Score[12].ToString("P2"),
            prediction.Score[13].ToString("P2"),
            prediction.Score[14].ToString("P2"),
            prediction.Score[15].ToString("P2"),
            prediction.Score[16].ToString("P2"),
            prediction.Score[17].ToString("P2"),
            prediction.Score[18].ToString("P2"),
            prediction.Score[19].ToString("P2"),
            prediction.Score[20].ToString("P2"),
            prediction.Score[21].ToString("P2"),
            prediction.Score[22].ToString("P2"),
            prediction.Score[23].ToString("P2"),
            prediction.Score[24].ToString("P2"),
            prediction.Score[25].ToString("P2"),
            prediction.Score[26].ToString("P2"),
                prediction.Score[27].ToString("P2"),

                    prediction.Score[28].ToString("P2"),
                    prediction.Score[29].ToString("P2"),
                    prediction.Score[30].ToString("P2"),
                    prediction.Score[31].ToString("P2"),
                    prediction.Score[32].ToString("P2"),
                    prediction.Score[33].ToString("P2"),
                    prediction.Score[34].ToString("P2"),
                    prediction.Score[35].ToString("P2"),
                    prediction.Score[36].ToString("P2"),
                    prediction.Score[38].ToString("P2"),
                    prediction.Score[39].ToString("P2"),
            prediction.Score[40].ToString("P2"),
            prediction.Score[41].ToString("P2"),
            prediction.Score[42].ToString("P2"),
            prediction.Score[43].ToString("P2"),
            prediction.Score[44].ToString("P2"),
            prediction.Score[45].ToString("P2"),
            prediction.Score[46].ToString("P2"));
            }

            // show results
            Console.WriteLine(table.ToString());








        }

    }
}
