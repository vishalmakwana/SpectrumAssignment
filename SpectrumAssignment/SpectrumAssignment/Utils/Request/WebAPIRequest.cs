using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SpectrumAssignment.Models.Request
{
    public class WebAPIRequest
    {
        public static async Task<T> ExecuteAsync<T>(RequestBody requestBody) where T : new()
        {

            var returnValue = new T();
            var stopwatch = Stopwatch.StartNew();
            var response = new HttpResponseMessage();
            try
            {
                var client = new HttpClient();
                string apiUrl= $"https://gorest.co.in/{requestBody.Uri}";

                //client.DefaultRequestHeaders.Add("Authorization", $"Bearer {Settings.UserDetails?.Token}");
#if DEBUG
                Debug.WriteLine($"{nameof(ExecuteAsync)}: {apiUrl}");
#endif
                var request = new HttpRequestMessage();
                request.Method = requestBody.HttpMethod;
                request.RequestUri = new Uri(apiUrl);
                if (requestBody.json != null)
                {
                    string jsonObject = JsonConvert.SerializeObject(requestBody.json);
                    request.Content = new StringContent(jsonObject, Encoding.UTF8, "application/json");
                }

                response = await client.SendAsync(request);

                stopwatch.Stop();
                var content = await response.Content.ReadAsStringAsync();
                
                switch (requestBody.ResponseType)
                {
                    case HttpResponseType.Generic:
                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            try
                            {
                                var responseDetails = JsonConvert.DeserializeObject<MainResponseStatus>(content);
                                if (returnValue.GetType() == typeof(MainResponseStatus))
                                {
                                    returnValue = (T)Convert.ChangeType(responseDetails, typeof(T));
                                }
                                else
                                {

                                    if (responseDetails?.Success == true)
                                    {
                                        if (responseDetails.Data != null)
                                        {
                                            returnValue = JsonConvert.DeserializeObject<T>(responseDetails.Data.ToString());
                                        }
                                    }
                                }

                                
                            }
                            catch (Exception ex)
                            {
                                returnValue = JsonConvert.DeserializeObject<T>(content);
                            }
                        }
                       
                        break;
                    case HttpResponseType.String:
                        returnValue = new T();
                        var successResponse = new SuccessOrStringResponse();
                        successResponse.Content = JsonConvert.DeserializeObject<string>(content);
                        successResponse.IsSuccess = false;
                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            successResponse.IsSuccess = true;
                        }
                        returnValue = (T)Convert.ChangeType(successResponse, typeof(T));
                        break;
                }
#if DEBUG
                Debug.WriteLine($"{nameof(ExecuteAsync)} response '{requestBody.Uri}' elapsed time: {stopwatch.ElapsedMilliseconds}ms");
#endif
            }
            catch (Exception ex)
            {
                stopwatch.Stop();

#if DEBUG
                Debug.WriteLine($"Error in {nameof(ExecuteAsync)} for '{requestBody.Uri}': {ex.Message}");
#endif
            }
            return returnValue;
        }
    }
}
