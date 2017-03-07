using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.IO;
using OpenQA.Selenium.Interactions;
using System.Threading;
using System.Threading.Tasks;



namespace ClassLibrary2
{
    
    // Set the driver
    
    [TestFixture]
    class Selenium2
    {

        IWebDriver driver = new ChromeDriver();


        // navigate to IET Acedemy B2C Site



        [Test]
        public void a_NavigatetoAcademyB2Curl()
        {

            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(60));
            driver.Navigate().GoToUrl("https://ietacademy.eu.crossknowledge.com/interfaces/login.php");
            driver.Manage().Window.Maximize();

        }


        // Enter Username and Password

        [Test]
        public void b2_EnterUsernameandpassword()
        {
            driver.FindElement(By.Id("fldUserName")).SendKeys("design");
            driver.FindElement(By.Id("fldPassword")).SendKeys("design");
            driver.FindElement(By.Name("submitButtonName")).SendKeys(Keys.Enter);

            Thread.Sleep(2000);
        }

        // Enter Language from login page dropdown menu
        // 

        [Test]
        public void b1_selectloginlanguage()
        {

            driver.FindElement(By.Id("fldLanguage")).Click();

            new SelectElement(driver.FindElement(By.Id("fldLanguage"))).SelectByText("English (United Kingdom)");

            Thread.Sleep(2000);

           // driver.FindElement(By.Id("fldlanguage")).SendKeys(Keys.Return);
           
        }


        // Navigate to my Profile from main screen from main site

        [Test]
        public void c_Navigatetomyprofile()
        {
            driver.FindElement(By.Id("tab_f5fa86ce-4309-11df-bd78-900956d89593")).SendKeys(Keys.Enter);
            Thread.Sleep(2000);

        }



        // Browswer Back function 

        [Test]
        public void d_BrowseBackfunction()
        {
            driver.Navigate().Back();
            Thread.Sleep(2000);
        }

        // Browswer Back function - duplicate of above - can delete it 

        [Test]
        public void d1_BrowseBackfunction()
        {
            driver.Navigate().Back();
            Thread.Sleep(2000);
        }

        // Navigate to My Activity from main site

        [Test]
        public void e_Myactivity()
        {
            driver.FindElement(By.Id("tab_myactivity")).SendKeys(Keys.Enter);
            Thread.Sleep(2000);
        }
        
        
        // Navigate to store from main site
        

        [Test]
        public void f_navigatetostore()
        {

            driver.Navigate().Back();
            Thread.Sleep(2000);
            driver.FindElement(By.ClassName("seeMoreButton")).SendKeys(Keys.Enter);
            Thread.Sleep(2000);
         }

        [Test]

        // Search All Types dropdown

        public void g_alltypedropdown()
        {
            driver.Navigate().GoToUrl("https://ietacademy.eu.crossknowledge.com/site/home");
            Thread.Sleep(2000);
          
            // button - 1013 - btnIconEl


            driver.FindElement(By.XPath("//*[@id='button-1013-btnIconEl']")).Click();
           
            //driver.FindElement(By.XPath("//*[@id='button-1013-btnIconEl']")).SendKeys(Keys.ArrowDown);
            //driver.FindElement(By.XPath("//*[@id='button-1013-btnIconEl']")).SendKeys(Keys.ArrowDown);
            //driver.FindElement(By.XPath("//*[@id='button-1013-btnIconEl']")).Click();


            IWebElement Button = driver.FindElement(By.XPath("//*[@id='button-1013-btnIconEl']"));
            Button.Click();
            Thread.Sleep(2000);

            Button.SendKeys(Keys.ArrowDown);
            Thread.Sleep(2000);

            Button.SendKeys(Keys.ArrowDown);
            //Button.SendKeys(Keys.Enter);

            Thread.Sleep(2000);
            Button.Click();
            //  driver.FindElement(By.XPath("//*[@id='button-1013-btnIconEl']")).SendKeys(Keys.Enter);




            new SelectElement(driver.FindElement(By.XPath("//*[@id='button-1013-btnIconEl']"))).SelectByText("Resource");
                





            //IWebElement Dropdown = driver.FindElement(By.XPath(//*[@id='button-1013-btnIconEl']));
            //IList<IWebElement> Resource=driver.FindElements(By.Name("Resource"));














        }

        [Test]

        public void h_multiurltest()
        { 

        // Multiple Content URLS defined within a file loaded and checked 
      
        String url;

            try

            {

                //Pass the file path and file name to the StreamReader constructor

                System.IO.StreamReader file = new StreamReader("C:\\url list.txt");

                //Read the first line of text in the file

                url = file.ReadLine();

                //Continue to read until you reach end of file

                while (url != null)
                {

                    //write the data in the console window

                    Console.WriteLine(url);
                    Debug.WriteLine(url);

                    driver.Navigate().GoToUrl(url);

                    Thread.Sleep(2000);

                    IWebElement myTitle = driver.FindElement(By.TagName("title"));

                    Console.WriteLine(myTitle);
                    Debug.WriteLine(myTitle);


                    //Read the next line

                    url = file.ReadLine();
                }

                //close the file

                file.Close();

                Console.ReadLine();

            }
            catch (Exception error)
            {
                Console.WriteLine("Exception: " + error.Message);
                Console.WriteLine("Exception: " + error.StackTrace);
            }

            finally
            {
                Console.WriteLine("Executing finally block.");

            }

            driver.Quit();

    }

}

    
}

