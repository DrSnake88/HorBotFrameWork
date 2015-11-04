using System;
using System.Collections.Generic;
using HorBotFrameWork.Core;
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

        [TestMethod]
        public void RetreivesAllSpansFromInput()
        {
            // Arrange
            const string input = "Hello, i am <span> Raynold van Heyningen</span> and i am a <span>  \"Programmer\"</span>";
            var expected = new List<string>() {" Raynold van Heyningen", "  \"Programmer\""};

            // Act
            var spans = Extract.Spans(input);

            // Assert
            CollectionAssert.AreEqual(expected, spans);
        }

        [TestMethod]
        public void RetreiveAllImagesFromInput()
        {
            // Arrange
            const string input = "<img src=\"http://www.google.nl/image.jpg\">Alt</img> and another one: <img src=\"http://image.jpg\">tekst</img>";
            var expected = new List<string>() { new Image("http://www.google.nl/image.jpg").Path, new Image("http://image.jpg").Path };

            // Act
            var images = Extract.Images(input);
            var result = new List<string>();

            foreach (var image in images)
            {
                result.Add(image.Path);
            }

            // Assert
            CollectionAssert.AreEqual(expected, result);
        }
    }
}
