using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using HuggingFaceHub.DTO.ChatCompletion;
using HuggingFaceHub.DTO.ChatCompletion.Response;
using HuggingFaceHub.DTO.FeatureExtraction.Request;
using HuggingFaceHub.DTO.FeatureExtraction.Response;
using HuggingFaceHub.Utilities;

namespace HuggingFaceHub.Service;

public class HuggingFaceClientService {

    public HuggingFaceClientService(string apiToken, string apiBaseUrl) {
        HuggingFaceGlobalConfig.ApiToken = apiToken;
        HuggingFaceGlobalConfig.ApiBaseUrl = apiBaseUrl;
    }
    
}