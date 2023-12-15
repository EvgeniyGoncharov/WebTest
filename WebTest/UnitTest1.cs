using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;

public class Tests
{
	
	private const string name = "Евгений";
	private const string surname = "Гончаров";
	private const string email = "work1.GoncharovEV";
	private const string realmail = "work.GoncharovEV";
	private const string password = "ckvopa2003M";

	private IWebDriver driver;
	private readonly By _signInButton = By.XPath("//span[text() = 'Создать аккаунт']");
	private readonly By _signInButton2 = By.XPath("//span[text() = 'Для личного использования']");

	private readonly By _nameInputButton = By.XPath("//input[@id = 'firstName']");
	private readonly By _surnameInputButton = By.XPath("//input[@id = 'lastName']");
	private readonly By _continueNamesButton = By.XPath("//span[@class = 'VfPpkd-vQzf8d']");

	private readonly By _dayInputButton = By.XPath("//input[@id = 'day']");
	private readonly By _monthSelectButton = By.XPath("//select[@id = 'month']");
	private readonly By _month2SelectButton = By.XPath("//option[@value = '3']");
	private readonly By _yearInputButton = By.XPath("//input[@id = 'year']");
	private readonly By _genderSelectButton = By.XPath("//select[@id = 'gender']");
	private readonly By _gender2SelectButton = By.XPath("//option[text() = 'Муж.']");
	private readonly By _continue2Button = By.XPath("//span[@class = 'VfPpkd-vQzf8d']");

	private readonly By _selectionButton = By.XPath("//div[text() = 'Создать собственный адрес Gmail']");
	private readonly By _continueSelectionButton = By.XPath("//span[text() = 'Далее']");

	private readonly By _mailNameInputButton = By.XPath("//input[@class='whsOnd zHQkBf']");
	private readonly By _continueButton = By.XPath("//span[text() = 'Далее']");

	private readonly By _passwordInputButton = By.XPath("//input[@name = 'Passwd']");
	private readonly By _password2InputButton = By.XPath("//input[@name= 'PasswdAgain']");


	private readonly By _authMailInputButton = By.XPath("//input[@id='identifierId']");
	private readonly By _authPasswInputButton = By.XPath("//input[@name='Passwd']");
	private readonly By _settingsButton = By.XPath("//input[@class='Ax4B8 ZAGvjd']");
	private readonly By _personsButton = By.XPath("//div[text()='Контакты']");                                                                                                               
	private readonly By _newPersonButton = By.XPath("//span[text()='Новый контакт']");
	private readonly By _newPerson2Button = By.XPath("//li[@class='JX41Qe-rymPhb-ibnC6b JX41Qe-rymPhb-ibnC6b-OWXEXe-hXIJHe JX41Qe-rymPhb-ibnC6b-OWXEXe-SfQLQb-Woal0c-RWgCYc JX41Qe-rymPhb-ibnC6b-OWXEXe-SfQLQb-M1Soyc-Bz112c  uoC0bf-OQAXze-OWXEXe-SfQLQb-Woal0c-RWgCYc']");
	private readonly By _name2InputButton = By.XPath("//input[@aria-label='Имя']");

	private readonly By _name2InputButton0 = By.XPath("//span[text()='Имя']");
	private readonly By _surname2InputButton = By.XPath("//input[@aria-label='Фамилия']");
	private readonly By _numberInputButton = By.XPath("//input[@aria-label='Телефон']");
	private readonly By _saveButton = By.XPath("//span[text() = 'Сохранить']");
	private readonly By _deleteButton = By.XPath("//span[text() = 'Отправить в корзину']");

	[SetUp]
	public void SetUp()
	{
		var options = new ChromeOptions();
		options.AddArguments(@"user-data-dir=c:\Users\Evgen\AppData\Local\Google\Chrome\User Data\");
		

		driver = new OpenQA.Selenium.Chrome.ChromeDriver();
		driver = new ChromeDriver(Directory.GetCurrentDirectory(), options);
		driver.Navigate().GoToUrl("https://accounts.google.com/InteractiveLogin");
		//driver.Navigate().GoToUrl("https://contacts.google.com/?hl=ru"); 
	}
	[Test]
	public void TestRegistrationPositive()
	{
		//переход к регистрации
		var signIn = driver.FindElement(_signInButton);
		signIn.Click();
		signIn = driver.FindElement(_signInButton2);
		signIn.Click();

		//страница имени
		var login = driver.FindElement(_nameInputButton);
		login.SendKeys(name);
		login = driver.FindElement(_surnameInputButton);
		login.SendKeys(surname);
		var cont = driver.FindElement(_continueNamesButton);
		cont.Click();

		Thread.Sleep(4000);

		//страница даты и пола

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

		/*страница выбора создания почты

		
		var select = driver.FindElement(_selectionButton);
		select.Click();
		cont = driver.FindElement(_continueSelectionButton);
		cont.Click();
		*/
		//страница названия почты
		Thread.Sleep(2000);
		var mailName = driver.FindElement(_mailNameInputButton);
		mailName.SendKeys(email);
		cont = driver.FindElement(_continueButton);
		cont.Click();

		//страница ввода паролей
		Thread.Sleep(2000);
		var pass1 = driver.FindElement(_passwordInputButton);
		pass1.SendKeys(password);
		var pass2 = driver.FindElement(_password2InputButton);
		pass2.SendKeys(password);
		cont = driver.FindElement(_continueButton);
		cont.Click();
	}
	[Test]
	public void TestAuthorisationPositive()
	{
		var mail = driver.FindElement(_authMailInputButton);
		mail.SendKeys(realmail);
		var cont = driver.FindElement(_continueButton);
		cont.Click();
		Thread.Sleep(4000);
		var passwd = driver.FindElement(_authPasswInputButton);
		passwd.SendKeys(password);
		cont = driver.FindElement(_continueButton);
		cont.Click();

		Thread.Sleep(3000);
		var apps = driver.FindElement(_settingsButton);
		apps.SendKeys("Контакты");

		Thread.Sleep(3000);
		apps = driver.FindElement(_personsButton);
		apps.Click();

	}
	[Test]
	public void TestMailPositive()
	{
		driver.Navigate().GoToUrl("https://contacts.google.com/?hl=ru");

		Thread.Sleep(3000);

		var person = driver.FindElement(_newPersonButton);
		person.Click();
		person = driver.FindElement(_newPerson2Button);
		person.Click();
		Thread.Sleep(3000);

		person = driver.FindElement(_name2InputButton);
		person.SendKeys(name);

		person = driver.FindElement(_surname2InputButton);
		person.SendKeys(surname);

		person = driver.FindElement(_numberInputButton);
		person.SendKeys("89801866925");

		person = driver.FindElement(_saveButton);
		person.Click();

	}
	[TearDown]
	public void TearDown() { }
}
