using System;
using System.IO;
using System.Reflection;
using System.Text;
using Com.Aspose.OMR.Api;
using Com.Aspose.OMR.Model;
using Com.Aspose.Storage.Api;

namespace Aspose.OMR.ConsoleClient
{
    class Program
    {
        // provide your own keys recieved by registrating at Aspose Cloud Dashboard
        private static string APIKEY = "xxxxxxx";
        private static string APPSID = "xxxxxxx";
        private static string BASEPATH = "http://api.aspose.cloud/v1.1";


        static string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Data\");

        static void Main(string[] args)
        {
            // 1- First step is to Create an OMR template using Aspose.OMR.Client application 
            // 2- Once your are done with OMR template creation, you can perform actions:
            // Correct Template
            // Finalize Template
            // Recognize Image
            // Above actions can be performed using REST API calls

            // Action #1: Run template correction
            OMRResponse response = RunOmrTask("CorrectTemplate", "original.jpg", File.ReadAllText(path + "100qSimple.omr"));

            // Get template id from Json response, which will be used during finalization and recognition process
            string templateId = response.Payload.Result.TemplateId;

            // Save copy of corrected template file on you disk
            File.WriteAllBytes(path + "CorrectedTemplate.bin", response.Payload.Result.ResponseFiles[0].Data);

            // Action #2: Run template Finalization
            RunOmrTask("FinalizeTemplate", "CorrectedTemplate.bin", templateId);

            // Action #3: Run Recognize image
            OMRResponse recognitionResponse = RunOmrTask("RecognizeImage", "photo.jpg", templateId);

            // Get recognition results as string from response Json
            string recognitionResults = Encoding.UTF8.GetString(recognitionResponse.Payload.Result.ResponseFiles[0].Data);

            Console.WriteLine(recognitionResults);
            Console.ReadLine();
        }

        /// <summary>
        /// Function to perform different actions on the template
        /// </summary>
        /// <param name="actionName">Name of action that is needed to performed</param>
        /// <param name="inputFileName">Input file name e.g. an image</param>
        /// <param name="functionParam">It can be some ID of an OMR template or OMR template</param>
        /// <returns></returns>
        private static Com.Aspose.OMR.Model.OMRResponse RunOmrTask(string actionName, string inputFileName, string functionParam)
        {
            // Create an instance of Aspose Storage Cloud API SDK
            OmrApi target = new OmrApi(APIKEY, APPSID, BASEPATH);

            // Create an instance of Aspose OMR Cloud API SDK
            StorageApi storageApi = new StorageApi(APIKEY, APPSID, BASEPATH);

            // Create an instance of function parameters
            OMRFunctionParam param = new OMRFunctionParam();
            param.FunctionParam = functionParam;

            // Set 3rd party cloud storage server (if any)
            string storage = null;
            string folder = null;

            // Upload source file to Aspose cloud storage
            storageApi.PutCreate(inputFileName, "", "", System.IO.File.ReadAllBytes(path + inputFileName));

            // Invoke Aspose.OMR Cloud SDK REST API
            Com.Aspose.OMR.Model.OMRResponse response = target.PostRunOmrTask(inputFileName, actionName, param, storage, folder);

            return response;
        }
    }
}
