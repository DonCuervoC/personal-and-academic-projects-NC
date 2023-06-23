using System.Net;

namespace ApiFilms.Models
{
    // This class is used to catch errors from server
    public class ResponseApi
    {
        public ResponseApi()
        {
            ErrorMessages = new List<string>();
        }

        public HttpStatusCode StatusCode { get; set; } // catch the status code
        public bool IsSuccess { get; set; } = true; // to know if the request was true or false
        public List<string> ErrorMessages { get; set; } // list with the possible errors that are obtained by the server
        public object Result { get; set; }

    }
}
