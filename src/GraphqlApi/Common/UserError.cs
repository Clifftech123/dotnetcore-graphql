
namespace dotnetcore_graphql.src.GraphqlApi.Common
{
  
     public class UserError
    {
        public UserError(string message, string code)
        {
            Message = message;
            Code = code;
        }

        public string Message { get; }
        public string Code { get; }
    }
}