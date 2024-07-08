using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Course.Shared.Dtos
{
    public class Response<T> // istediğim türden göndereceğimiz için where ile kısıtlamıyoruz.
    {
        public T Data  { get; private set; }

        [JsonIgnore]
        public int StatusCode { get; set; } // tekrardan seriazae edilmesini istemiyorum  kullanıcıya göstermiyeceğiz development ksmında kullanacağız.

        [JsonIgnore]
        public bool IsSuccesful { get; set; }


        public List<string> Errors { get; set; }

        //static Factory Method 
        public static Response<T> Success(T data, int satatusCode)
        {
            return new Response<T> { Data = data, StatusCode = satatusCode, IsSuccesful = true };

        }

        public static Response<T> Success (int satatusCode) 
        {
            return new Response<T> {Data=default(T),StatusCode = satatusCode,IsSuccesful = true};


        }

        public static Response<T> Fail (List<string>erorrs, int satatusCode) 
        {
            return new Response<T>
            {
                Errors = erorrs,
                StatusCode = satatusCode,
                IsSuccesful = false
            };
        }

        public static Response<T> Fail(string erorrs, int satatusCode)
        {
           return new Response<T> { Errors= new List<string>() { erorrs},StatusCode = satatusCode,IsSuccesful=false};
        }
    }
}
