using System;
using System.Collections.Generic;
using HorBotFrameWork.Web;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HorBotFrameWork.Tests.Web
{
    [TestClass]
    public class ExtractTests
    {
        [TestMethod]
        public void RetreivesAllParagraphsFromInput()
        {
            // Arrange
            const string input = "Hello, i am <p>Raynold van Heyningen</p> and i am a <p>Programmer</p>";
            var expected = new List<string>() {"Raynold van Heyningen", "Programmer"};

            // Act
            var paragraphs = Extract.Paragraphs(input);

            // Assert
            CollectionAssert.AreEqual(expected, paragraphs);
        }
    }
}
