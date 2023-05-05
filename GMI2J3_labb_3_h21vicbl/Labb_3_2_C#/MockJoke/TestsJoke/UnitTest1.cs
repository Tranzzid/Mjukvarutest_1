using NUnit.Framework;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Json;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Runtime.CompilerServices;
using Moq;
using System;
using Moq.Protected;

namespace TestsJoke
{
	[TestFixture]
	public class WebAPITests
	{
		private WebAPI _webApi;
		private Mock<HttpMessageHandler> _mockHttpMessageHandler;
		private HttpClient _httpClient;

		[SetUp]
		public void Setup()
		{
			_mockHttpMessageHandler = new Mock<HttpMessageHandler>();
			_httpClient = new HttpClient(_mockHttpMessageHandler.Object);
			_webApi = new WebAPI { client = _httpClient };
		}

		[Test]
		public async Task LenJokeAsync_ReturnsJokeLength()
		{
			// Arrange
			string joke = "Chuck Norris can divide by zero.";
			_mockHttpMessageHandler.Protected()
				.Setup<Task<HttpResponseMessage>>("SendAsync",
					ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
				.ReturnsAsync(new HttpResponseMessage
				{
					StatusCode = HttpStatusCode.OK,
					Content = new StringContent($"{{ \"value\": \"{joke}\" }}"),
				});

			// Act
			int length = await _webApi.LenJokeAsync();

			// Assert
			Assert.AreEqual(joke.Length, length);
		}

		[Test]
		public async Task GetJokeAsync_ReturnsJoke()
		{
			// Arrange
			string joke = "Chuck Norris counted to infinity. Twice.";
			_mockHttpMessageHandler.Protected()
				.Setup<Task<HttpResponseMessage>>("SendAsync",
					ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
				.ReturnsAsync(new HttpResponseMessage
				{
					StatusCode = HttpStatusCode.OK,
					Content = new StringContent($"{{ \"value\": \"{joke}\" }}"),
				});

			// Act
			string result = await _webApi.GetJokeAsync();

			// Assert
			Assert.AreEqual(joke, result);
		}

		[Test]
		public async Task GetJokeAsync_ReturnsErrorMessageOnFailure()
		{
			// Arrange
			_mockHttpMessageHandler.Protected()
				.Setup<Task<HttpResponseMessage>>("SendAsync",
					ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
				.ReturnsAsync(new HttpResponseMessage
				{
					StatusCode = HttpStatusCode.InternalServerError,
				});

			// Act
			string result = await _webApi.GetJokeAsync();

			// Assert
			Assert.AreEqual("No jokes are available", result);
		}
	}
}





//public class Tests
//{
//	private Mock<HttpClient> httpClientMock;
//	private WebAPI program;
//	public string url = "https://api.chucknorris.io/jokes/random";

//	[SetUp]
//	public void Setup()
//	{
//		var httpClientMock = new Mock<HttpClient>();
//		var program = new WebAPI();

//	}

//	[Test]
//	public async Task GetJokeAsync_ReturnsNonEmptyString()
//	{
//		// Arrange
//		var response = new HttpResponseMessage(HttpStatusCode.OK);
//		response.Content = new StringContent("{\"value\": \"test joke\"}");
//		httpClientMock.Setup(c => c.GetAsync(url))
//			.ReturnsAsync(response);

//		// Act
//		var result = await program.GetJokeAsync();

//		// Assert
//		Assert.AreEqual("test joke", result);
//	}

//	[Test]
//	public async Task GetJokeAsync_ReturnsFallbackStringOnFailure()
//	{
//		// Arrange
//		var response = new HttpResponseMessage(HttpStatusCode.NotFound);
//		httpClientMock.Setup(c => c.GetAsync(url))
//			.ReturnsAsync(response);

//		// Act
//		var result = await program.GetJokeAsync();

//		// Assert
//		Assert.AreEqual("No jokes are available", result);
//	}

//	[Test]
//	public async Task LenJokeAsync_ReturnsJokeLength()
//	{
//		// Arrange
//		var response = new HttpResponseMessage(HttpStatusCode.OK);
//		response.Content = new StringContent("{\"value\": \"test joke\"}");
//		httpClientMock.Setup(c => c.GetAsync(url))
//			.ReturnsAsync(response);

//		// Act
//		var result = await program.LenJokeAsync();

//		// Assert
//		Assert.AreEqual(9, result);
//	}
//}





//[TestFixture]
//public class ProgramTests
//{
//	private Mock<HttpClient> httpClientMock;
//	private Program program;

//	[SetUp]
//	public void Setup()
//	{
//		httpClientMock = new Mock<HttpClient>();
//		program = new Program(httpClientMock.Object);
//	}

//	[Test]
//	public async Task GetJokeAsync_ReturnsNonEmptyString()
//	{
//		// Arrange
//		var response = new HttpResponseMessage(HttpStatusCode.OK);
//		response.Content = new StringContent("{\"value\": \"test joke\"}");
//		httpClientMock.Setup(c => c.GetAsync("https://api.chucknorris.io/jokes/random"))
//			.ReturnsAsync(response);

//		// Act
//		var result = await program.GetJokeAsync();

//		// Assert
//		Assert.AreEqual("test joke", result);
//	}

//	[Test]
//	public async Task GetJokeAsync_ReturnsFallbackStringOnFailure()
//	{
//		// Arrange
//		var response = new HttpResponseMessage(HttpStatusCode.NotFound);
//		httpClientMock.Setup(c => c.GetAsync("https://api.chucknorris.io/jokes/random"))
//			.ReturnsAsync(response);

//		// Act
//		var result = await program.GetJokeAsync();

//		// Assert
//		Assert.AreEqual("No jokes are available", result);
//	}

//	[Test]
//	public async Task LenJokeAsync_ReturnsJokeLength()
//	{
//		// Arrange
//		var response = new HttpResponseMessage(HttpStatusCode.OK);
//		response.Content = new StringContent("{\"value\": \"test joke\"}");
//		httpClientMock.Setup(c => c.GetAsync("https://api.chucknorris.io/jokes/random"))
//			.ReturnsAsync(response);

//		// Act
//		var result = await program.LenJokeAsync();

//		// Assert
//		Assert.AreEqual(9, result);
//	}
//}





