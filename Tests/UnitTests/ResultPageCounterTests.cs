using WebApi;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace UnitTests
{
    public class ResultPageCounterTests
    {
       
        readonly ResultPageCounter sut;
        readonly Mock<IResultPageParser> parserMock;
        

        public ResultPageCounterTests()
        {
            parserMock = new Mock<IResultPageParser>();
            sut = new ResultPageCounter(parserMock.Object);
        }

        [Fact]
        public void Should_throw_exception_for_null_html_Source()
        {
            string htmlSource = null;
            Action testCode = () => sut.CountUrlOccurence(htmlSource, "infotrack.co.uk");

            Assert.Throws<ArgumentNullException>(testCode);

        }

        [Fact]
        public void Should_throw_exception_for_null_url()
        {
            string htmlSource = "<div></div>";
            Action testCode = () => sut.CountUrlOccurence(htmlSource, null);

            Assert.Throws<ArgumentNullException>(testCode);

        }

        [Fact]
        public void Should_return_zero_for_no_result()
        {
            string htmlSource = "<div></div>";
            var emptyResult = new List<string>();
            parserMock.Setup(x => x.Parse(It.IsAny<string>())).Returns(emptyResult);

            string result = sut.CountUrlOccurence(htmlSource, "url");

            result.Should().Be("0");

        }

        [Fact]
        public void Should_format_response_correctly()
        {
            string url = "infotrack.co.uk";
            string htmlSource = @"<div>                                
                                <a href='infotrack.co.uk'></a>
                                <a href='infotrack.co.uk'></a>
                                </div>";
            var result = new List<string>() { "<a href='infotrack.co.uk'></a>", "<a href='infotrack.co.uk'></a>" };
            parserMock.Setup(x => x.Parse(It.IsAny<string>())).Returns(result);

            string occurence = sut.CountUrlOccurence(htmlSource, url);

            occurence.Should().Be("1,2");

        }

        [Fact]
        public void Should_return_number_of_occurence()
        {
            string url = "infotrack.co.uk";
            string htmlSource = @"<div>
                                <a href='infotrack.co.uk'></a>
                                <a href='infotrack.co.uk'></a>
                                <a href='infotrack.co.uk'></a>
                                </div>";
            var result = new List<string>() { "<a href='infotrack.co.uk'></a>", "<a href='infotrack.co.uk'></a>", "<a href='infotrack.co.uk'></a>" };
            parserMock.Setup(x => x.Parse(It.IsAny<string>())).Returns(result);

            string occurence = sut.CountUrlOccurence(htmlSource, url);

            occurence.Should().Be("1,2,3");

        }
    }
}
