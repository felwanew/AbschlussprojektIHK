using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AbschlussprojektIHK
{
    class Tests
    {
        [Test]
        public async void ClsEmailTest()
        {
            // Arrange
            //var webService = MockRepository.GenerateStub<IWebService>();
            //webService.Expect(x => x.GetDataAsync()).Return(new Task<bool>(() => false));

            //Mock<checkEmployee> chk = new Mock<checkEmployee>();  
            //chk.Setup(x => x.checkEmp()).Returns(true);

            string sTitle = "Test";
            string sText = "Test";

            // Act
            var result = await ClsEmail.Send_EmailAsync(sTitle, sText);
            // Assert
            
            Assert.That(result, Is.EqualTo(""));
        }
        void CreateOrEditUserTest()
        {
            // Arrange
            string Firstname = "Max";
            string Familyname = "Müller";
            string MailOfInstructor = "Alfons@outlook.de";
            string EmailUser = "Zitterbacke@outlook.de";
            string Password = "Qwertzu1234.";

            // Act
            var result = new StartWindow.Btn_Submit_Click(new object sender, RoutedEventArgs e);

            // Assert
            Assert.That(result);
        }
        void OnStartupTest()
        {
            // Arrange
            String text = "-1.5";
            int index = 0;

            // Act
            boolean result = MyDecimal.isDecimal(text, index);

            // Assert
            assert.That(result, is (true));
        }
    }
}
