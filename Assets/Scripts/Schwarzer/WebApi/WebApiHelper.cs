﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using UnityEngine;

namespace Schwarzer.Lanotalium.WebApi
{
    public class WebApiHelper
    {
        public static string WebApiUri = "http://api.lanotalium.cn/";
        public static IEnumerator PostObjectCoroutine(string Route, object Object, ObjectWrap<string> Responce = null)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(WebApiUri + Route);
            httpWebRequest.ContentType = "application/json; charset=utf-8";
            httpWebRequest.Method = "POST";
            httpWebRequest.Accept = "application/json; charset=utf-8";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(JsonConvert.SerializeObject(Object));
                streamWriter.Flush();
                streamWriter.Close();

                var httpResponseTask = httpWebRequest.GetResponseAsync();
                while (!httpResponseTask.IsCompleted)
                {
                    yield return null;
                }
                try
                {
                    var httpResponse = (HttpWebResponse)httpResponseTask.Result;
                    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                    {
                        var result = streamReader.ReadToEnd();
                        if (Responce != null)
                        {
                            Responce.Reference = result;
                        }
                    }
                }
                catch (Exception Ex)
                {
                    Debug.Log(Ex);
                }
            }
        }
        public static async Task<string> PostObjectAsync(string Route, object Object)
        {
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(WebApiUri + Route);
                httpWebRequest.ContentType = "application/json; charset=utf-8";
                httpWebRequest.Method = "POST";
                httpWebRequest.Accept = "application/json; charset=utf-8";
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    streamWriter.Write(JsonConvert.SerializeObject(Object));
                    streamWriter.Flush();
                    streamWriter.Close();

                    var httpResponse = (HttpWebResponse)await httpWebRequest.GetResponseAsync();
                    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                    {
                        var result = streamReader.ReadToEnd();
                        //Debug.Log(result);
                        return result;
                    }
                }
            }
            catch (Exception Ex)
            {
                Debug.Log(Ex);
                return null;
            }
        }
        public static async Task<string> PostStringAsync(string Route, string String)
        {
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(WebApiUri + Route);
                httpWebRequest.ContentType = "application/x-www-form-urlencoded; charset=utf-8";
                httpWebRequest.Method = "POST";
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    streamWriter.Write("=" + String);
                    streamWriter.Flush();
                    streamWriter.Close();

                    var httpResponse = (HttpWebResponse)await httpWebRequest.GetResponseAsync();
                    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                    {
                        var result = streamReader.ReadToEnd();
                        //Debug.Log(result);
                        return result;
                    }
                }
            }
            catch (Exception Ex)
            {
                Debug.Log(Ex);
                return null;
            }
        }
    }
}