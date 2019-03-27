using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;


namespace TestArrayCalc.Controllers
{
    public class ArrayCalcController : ApiController
    {

        [HttpGet]
        public string Reverse([FromUri]int[] productIds)
        {
            string output = "";
            int arrayLength = productIds.Length;
            int midway = arrayLength / 2;
            if (arrayLength % 2 > 0)
                midway++;

            for (int i = 0; i < midway; i++)
            {
                int temp = productIds[i];

                productIds[i] = productIds[arrayLength - (i + 1)];
                productIds[arrayLength - (i + 1)] = temp;

                if (output == String.Empty)
                {
                    output = productIds[i].ToString();
                }
                else
                {
                    output = output + "," + productIds[i];
                }
            }

            for (int i = midway; i < arrayLength; i++)
            {
                output = output + "," + productIds[i];
            }

            return "[" + output + "]";
        }


        [HttpGet]
        public string DeletePart([FromUri]int position, [FromUri]int[] productIds)
        {
            string output = "";
            int arrayLength = productIds.Length;

            int[] outputArr = new int[productIds.Length - 1];

            int counter = 0;
            for (int i = 0; i < arrayLength; i++)
            {
                if (i != (position - 1))
                {
                    outputArr[counter] = productIds[i];
                    counter++;
                }
            }

            for (int i = 0; i < arrayLength - 1; i++)
            {
                if (output == String.Empty)
                {
                    output = outputArr[i].ToString();
                }
                else
                {
                    output = output + "," + outputArr[i];
                }
            }

            return "[" + output + "]";
        }


    }


}


