using System;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ButtonClickTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var driver = new ChromeDriver(@"C:\Users\cswit\.nuget\packages\selenium.webdriver.chromedriver\2.40.0\driver\win32");
            driver.Navigate().GoToUrl("http://localhost:3000/");

            /*Click The Button*/

            IWebElement element = driver.FindElement(By.XPath("//*[@data-test-id='render-challenge']"));
            System.Threading.Thread.Sleep(1000);
            element.Click();
            //Console.Read();

            /*Find Equilibrium*/

            int[] arr1 = new int[9];
            int[] arr2 = new int[9];
            int[] arr3 = new int[9];
            IWebElement[] webArr1 = new IWebElement[9];

            //Row One
            webArr1[0] = driver.FindElement(By.XPath("//*[@data-test-id='array-item-1-0']"));
            webArr1[1] = driver.FindElement(By.XPath("//*[@data-test-id='array-item-1-1']"));
            webArr1[2] = driver.FindElement(By.XPath("//*[@data-test-id='array-item-1-2']"));
            webArr1[3] = driver.FindElement(By.XPath("//*[@data-test-id='array-item-1-3']"));
            webArr1[4] = driver.FindElement(By.XPath("//*[@data-test-id='array-item-1-4']"));
            webArr1[5] = driver.FindElement(By.XPath("//*[@data-test-id='array-item-1-5']"));
            webArr1[6] = driver.FindElement(By.XPath("//*[@data-test-id='array-item-1-6']"));
            webArr1[7] = driver.FindElement(By.XPath("//*[@data-test-id='array-item-1-7']"));
            webArr1[8] = driver.FindElement(By.XPath("//*[@data-test-id='array-item-1-8']"));

            for (int i = 0; i < arr1.Length; i++ )
            {
                IWebElement arrayNumber = webArr1[i];
                arr1[i] = ConvertToInt(arrayNumber.GetAttribute("innerText"));
            }

            //Row Two
            webArr1[0] = driver.FindElement(By.XPath("//*[@data-test-id='array-item-2-0']"));
            webArr1[1] = driver.FindElement(By.XPath("//*[@data-test-id='array-item-2-1']"));
            webArr1[2] = driver.FindElement(By.XPath("//*[@data-test-id='array-item-2-2']"));
            webArr1[3] = driver.FindElement(By.XPath("//*[@data-test-id='array-item-2-3']"));
            webArr1[4] = driver.FindElement(By.XPath("//*[@data-test-id='array-item-2-4']"));
            webArr1[5] = driver.FindElement(By.XPath("//*[@data-test-id='array-item-2-5']"));
            webArr1[6] = driver.FindElement(By.XPath("//*[@data-test-id='array-item-2-6']"));
            webArr1[7] = driver.FindElement(By.XPath("//*[@data-test-id='array-item-2-7']"));
            webArr1[8] = driver.FindElement(By.XPath("//*[@data-test-id='array-item-2-8']"));

            for (int i = 0; i < arr1.Length; i++)
            {
                IWebElement arrayNumber = webArr1[i];
                arr2[i] = ConvertToInt(arrayNumber.GetAttribute("innerText"));
            }

            //Row Two
            webArr1[0] = driver.FindElement(By.XPath("//*[@data-test-id='array-item-3-0']"));
            webArr1[1] = driver.FindElement(By.XPath("//*[@data-test-id='array-item-3-1']"));
            webArr1[2] = driver.FindElement(By.XPath("//*[@data-test-id='array-item-3-2']"));
            webArr1[3] = driver.FindElement(By.XPath("//*[@data-test-id='array-item-3-3']"));
            webArr1[4] = driver.FindElement(By.XPath("//*[@data-test-id='array-item-3-4']"));
            webArr1[5] = driver.FindElement(By.XPath("//*[@data-test-id='array-item-3-5']"));
            webArr1[6] = driver.FindElement(By.XPath("//*[@data-test-id='array-item-3-6']"));
            webArr1[7] = driver.FindElement(By.XPath("//*[@data-test-id='array-item-3-7']"));
            webArr1[8] = driver.FindElement(By.XPath("//*[@data-test-id='array-item-3-8']"));

            for (int i = 0; i < arr1.Length; i++)
            {
                IWebElement arrayNumber = webArr1[i];
                arr3[i] = ConvertToInt(arrayNumber.GetAttribute("innerText"));
            }







            //arr1[0] = firstRowFirstNumber;
            //string number = firstRowFirstNumber.GetAttribute("innerText");


            IWebElement submitText1 = driver.FindElement(By.XPath("//*[@data-test-id='submit-1']"));
            IWebElement submitText2 = driver.FindElement(By.XPath("//*[@data-test-id='submit-2']"));
            IWebElement submitText3 = driver.FindElement(By.XPath("//*[@data-test-id='submit-3']"));
            IWebElement submitText4 = driver.FindElement(By.XPath("//*[@data-test-id='submit-4']"));

            /*string arrayText = "";
            foreach (int val in arr1)
            {
                arrayText = arrayText + " " + val;
            }*/

            

            //Calculate And Submit Answers

            string answer1 = GetEquilibrium(arr1) + "";
            string answer2 = GetEquilibrium(arr2) + "";
            string answer3 = GetEquilibrium(arr3) + "";

            submitText1.SendKeys(answer1);
            submitText2.SendKeys(answer2);
            submitText3.SendKeys(answer3);
            submitText4.SendKeys("Christopher Withall");

            IWebElement rowSubmit = driver.FindElement(By.CssSelector("[tabindex='0']"));
            System.Threading.Thread.Sleep(1000);
            rowSubmit.Click();


        }

        static int GetEquilibrium(int[] arr)
        {
            int iLength = arr.Length;
            int iSum = 0, iLeftSum = 0, iEqualIndex = -1;

            for (int i = 0; i < iLength; i++)
                iSum += arr[i];

            for (int i=0; i<iLength;i++)
            {
                iSum = iSum - arr[i];
                if(iLeftSum == iSum)
                {
                    iEqualIndex = i;
                    break;
                }

                iLeftSum = iLeftSum + arr[i];

            }


            return iEqualIndex;
        }

        static int ConvertToInt(string txt)
        {
            int convertedTxt = Int32.Parse(txt);

            return convertedTxt;
        }

    }
}
