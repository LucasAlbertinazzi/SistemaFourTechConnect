using AppFourTechConnect.Classes.Uteis;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace AppFourTechConnect.Services.Principal
{
    public class APIErroLog
    {
        private HttpClient _httpClient;

        public APIErroLog()
        {
            _httpClient = new HttpClient() { Timeout = new TimeSpan(0, 0, 2) };
        }

        public async Task VerficaExistenciadeLogs()
        {
            var filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "AppPousadaLog.txt");

            if (File.Exists(filePath))
            {
                using (var _content = new MultipartFormDataContent())
                {
                    // Adiciona o arquivo ao conteúdo da requisição
                    var fileContent = new ByteArrayContent(File.ReadAllBytes(filePath));
                    fileContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
                    {
                        Name = "file", // O nome do campo deve corresponder ao nome esperado pela API
                        FileName = Path.GetFileName(filePath)
                    };

                    _content.Add(fileContent);

                    // Serialize o objeto versionInfo para JSON
                    string json = JsonConvert.SerializeObject(_content);
                    HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

                    string url = InfoGlobal.apiApp + "/Log/erro-file";
                    HttpResponseMessage response = await _httpClient.PostAsync(url, content);

                    // Verifique se a resposta foi bem-sucedida
                    response.EnsureSuccessStatusCode();

                    // Verifique a resposta
                    if (response.IsSuccessStatusCode)
                    {
                        File.Delete(filePath);
                    }
                }
            }
        }
    }
}
