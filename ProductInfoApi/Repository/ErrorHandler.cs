using System.Collections.Generic;
using System.Net;

namespace ProductInfoApi.Repository
{
    public class ErrorHandler
    {
        public static IEnumerable<object> ParsingBoolError()
        {
            var error = new List<object>
           {
               HttpStatusCode.BadRequest, "Resource expected to be either true or false."
           };
            return error;
        }


        public static IEnumerable<object> ParsingDoubleError()
        {
            var error = new List<object>
            {
                HttpStatusCode.BadRequest, "Resource is not double."
            };
            return error;
        }

        public static IEnumerable<object> ScreenTypeError()
        {
            var error = new List<object>
            {
                HttpStatusCode.BadRequest, "Invalid Screen Type."
            };
            return error;
        }

        public static IEnumerable<object> EmptyInputProductIdList()
        {
            var error = new List<object>
            {
                HttpStatusCode.BadRequest, "List of product IDs provided is empty."
            };
            return error;
        }
    }


}