using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Business.Services.OutsideService.PaymentService;
using InvoiceManagement.Core.Utilities.Results;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace InvoiceManagement.Business.Services.OtherServices.PaymentService
{
    public class PaymentManager : IPaymentService
    {
        private readonly IConfiguration Configuration;

        public PaymentManager(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public async Task<PaymentResult> PayOrder(PaymentOrder payOrder)
        {
            payOrder.CompanyId = Configuration["CreditCardService:CompanyId"];
            PaymentResult result;
            string requestUrl = String.Join("/", Configuration["CreditCardService:ServiceApiURL"], "Pay");
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(payOrder), Encoding.UTF8, "application/json");
                using (var response = await httpClient.PostAsync(requestUrl,content))
                {
                    
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<PaymentResult>(apiResponse);
                }
            }

            return result;
        }

        public async Task<IDataResult<object>> CompanyAllPayOrder()
        {
            object returnList ;
            string requestUrl = String.Join("/", Configuration["CreditCardService:ServiceApiURL"], "Pay", "GetCompanyId", Configuration["CreditCardService:CompanyId"]);
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(requestUrl))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    returnList = JsonConvert.DeserializeObject(apiResponse);
                }
            }

            return new DataResult<object>(returnList,true);
        }
    }
}
