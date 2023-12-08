using NUnit.Framework;
using OpenQA.Selenium;

public class Tests
{
	
	private const string name = "�������";
	private const string surname = "��������";
	private const string mail = "GoncharovEV";
	private const string password = "ckvopa2003M";

	private IWebDriver driver;
	private readonly By _signInButton = By.XPath("//span[text() = '������� �������']");
	private readonly By _signInButton2 = By.XPath("//span[text() = '��� ������� �������������']");

	private readonly By _nameInputButton = By.XPath("//input[@id = 'firstName']");
	private readonly By _surnameInputButton = By.XPath("//input[@id = 'lastName']");
	private readonly By _continueButton = By.XPath("//span[@class = 'VfPpkd-vQzf8d']");

	private readonly By _dayInputButton = By.XPath("//input[@id = 'day']");
	private readonly By _monthSelectButton = By.XPath("//select[@id = 'month']");
	private readonly By _month2SelectButton = By.XPath("//option[@value = '3']");
	private readonly By _yearInputButton = By.XPath("//input[@id = 'year']");
	private readonly By _genderSelectButton = By.XPath("//select[@id = 'gender']");
	private readonly By _gender2SelectButton = By.XPath("//option[text() = '���.']");
	private readonly By _continue2Button = By.XPath("//span[@class = 'VfPpkd-vQzf8d']");

	private readonly By _selectionButton = By.XPath("//div[text() = '������� ����������� ����� Gmail']");
	private readonly By _continueSelectionButton = By.XPath("//span[text() = '�����']");

	private readonly By _mailNameInputButton = By.XPath("//input[@class='whsOnd zHQkBf']");
	private readonly By _continueMailButton = By.XPath("//span[text() = '�����']");
	//private readonly By _continueButton = By.XPath("//span[@class = 'VfPpkd-vQzf8d']");

	[SetUp]
	public void SetUp()
	{
		driver = new OpenQA.Selenium.Chrome.ChromeDriver();
		driver.Navigate().GoToUrl("https://accounts.google.com/InteractiveLogin");
	}
	[Test]
	public void Test1()
	{
		//������� � �����������
		var signIn = driver.FindElement(_signInButton);
		signIn.Click();
		signIn = driver.FindElement(_signInButton2);
		signIn.Click();

		//�������� �����
		var login = driver.FindElement(_nameInputButton);
		login.SendKeys(name);
		login = driver.FindElement(_surnameInputButton);
		login.SendKeys(surname);
		var cont = driver.FindElement(_continueButton);
		cont.Click();

		Thread.Sleep(4000);

		//�������� ���� � ����

		var gender = driver.FindElement(_genderSelectButton);
		gender.Click();
		gender = driver.FindElement(_gender2SelectButton);
		gender.Click();
		Thread.Sleep(1000);

		var date = driver.FindElement(_dayInputButton);
		date.SendKeys("21");

		date = driver.FindElement(_monthSelectButton);
		date.Click();
		date = driver.FindElement(_month2SelectButton);
		date.Click();

		date = driver.FindElement(_yearInputButton);
		date.SendKeys("2003");		

		cont = driver.FindElement(_continue2Button);
		cont.Click();

		/**�������� ������ �������� �����

		
		var select = driver.FindElement(_selectionButton);
		select.Click();
		cont = driver.FindElement(_continueSelectionButton);
		cont.Click();
		*/
		//�������� �������� �����
		Thread.Sleep(2000);
		var mailName = driver.FindElement(_mailNameInputButton);
		mailName.SendKeys(mail);
		cont = driver.FindElement(_continueMailButton);
		cont.Click();
	}
	[TearDown]
	public void TearDown() { }
}
