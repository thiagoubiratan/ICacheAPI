using Newtonsoft.Json;

namespace ICache.Api.Utils
{
    public class ApiResponse
    {
        public int StatusCode { get; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Message { get; }
        public ApiResponse(int statusCode, string message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageForStatusCode(statusCode);
        }

        private static string GetDefaultMessageForStatusCode(int statusCode)
        {
            switch (statusCode)
            {
                case 200:
                    return "Opração realizada com sucesso!";
                case 401:
                    return "Não autorizado (não autenticado)";
                case 404:
                    return "Recurso não encontrado";
                case 405:
                    return "Método não permitido";
                case 409:
                    return "não é possivel registrar um item duplicado";
                case 500:
                    return "Um erro não tratado ocorreu no request";
                default:
                    return null;
            }
        }
    }
}