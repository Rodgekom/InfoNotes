using InfoNotes.Models;
using PortableRest;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace InfoNotes
{
    public class Proxy
    {
        private const string URL = "http://apinotes.azurewebsites.net/";
        private static string user = "91778-91678-91680";
        public static async Task<Note> postNote(Note note)
        {
            var client = new RestClient { BaseUrl = URL };

            RestRequest request = new RestRequest("notes/", HttpMethod.Post);
            request.ContentType = ContentTypes.Json;
            request.AddParameter(note);
            var response = await client.ExecuteAsync<Note>(request);

            return response;
        }

        public static List<Note> getNotes()
        {
            var client = new RestClient { BaseUrl = URL };
            var endpoint = "notes/?user=" + user;
            RestRequest request = new RestRequest(endpoint, HttpMethod.Get);
            var response = client.ExecuteAsync<List<Note>>(request);
            return response.Result;
        }


    }
}
