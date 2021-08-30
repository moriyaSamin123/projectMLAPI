﻿// This file was auto-generated by ML.NET Model Builder. 
using Microsoft.ML;
using Microsoft.ML.Data;
using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;

namespace WebApplicationAPI
{
    public partial class PredicationModel
    {
        /// <summary>
        /// model input class for PredicationModel.
        /// </summary>
        #region model input class
        public class ModelInput
        {
            [ColumnName(@"title")]
            public string title { get; set; }

            [ColumnName(@"refT")]
            public string refT { get; set; }

            [ColumnName(@"isRefQK")]
            public float isRefQK { get; set; }

        }

        #endregion

        /// <summary>
        /// model output class for PredicationModel.
        /// </summary>
        #region model output class
        public class ModelOutput
        {
            [ColumnName("PredictedLabel")]
            public float Prediction { get; set; }

            public float[] Score { get; set; }
        }

        #endregion

        private static string MLNetModelPath = Path.GetFullPath("PredicationModel.zip");

        /// <summary>
        /// Use this method to predict on <see cref="ModelInput"/>.
        /// </summary>
        /// <param name="input">model input.</param>
        /// <returns><seealso cref=" ModelOutput"/></returns>
        public static ModelOutput Predict(ModelInput input)
        {
            MLContext mlContext = new MLContext();

            // Load model & create prediction engine
            ITransformer mlModel = mlContext.Model.Load(MLNetModelPath, out var modelInputSchema);
            var predEngine = mlContext.Model.CreatePredictionEngine<ModelInput, ModelOutput>(mlModel);

            ModelOutput result = predEngine.Predict(input);
            return result;
        }
    }
}