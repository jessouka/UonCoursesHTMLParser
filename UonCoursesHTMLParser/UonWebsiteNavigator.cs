using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Microsoft.Win32.SafeHandles;
using System.Runtime.InteropServices;
using System.ComponentModel;

namespace UonCoursesHTMLParser
{
	public class UonWebsiteNavigator
	{
		ChromeDriver driver;
		const string url = "https://spprd.newcastle.edu.au/scientia/sws2018prd/";
		IWebElement courseDropDown;

		public UonWebsiteNavigator(ChromeDriver driver)
		{
			this.driver = driver;
		}

		public void NavigateToUonWebsite()
		{
			driver.Navigate().GoToUrl(url);
		}

		public ReadOnlyCollection<IWebElement> FindCourseDropDownOptions()
		{
			return findAndSetCourseDropDown()
				.FindElements(By.TagName("option"));
		}

		public IWebElement NavigateToAndFindLessonTable(Course course)
		{
			selectOptionFromCourseDropDown(course);
			pressSubmitButton();

			return driver.FindElement(By.Id("DataTables_Table_0"));
		}

		public void ReturnToCourseSelectionPage()
		{
			driver.Navigate().Back();
		}

		void selectOptionFromCourseDropDown(Course course)
		{
			var dropDownList = driver.FindElement(By.Id("dlObject"));
			SelectElement selectThis = new SelectElement(dropDownList);
			selectThis.SelectByText(course.SelectionOption);
		}

		IWebElement findAndSetCourseDropDown()
		{
			return driver.FindElement(By.Id("dlObject"));
		}

		void pressSubmitButton()
		{
			driver.FindElement(By.Id("bGetTimetable")).Click();
		}
	}
}
