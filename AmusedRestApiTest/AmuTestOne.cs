using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestSharp;
using Xunit;
using FluentAssertions;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace AmusedRestApiTest
{
    public class AmuTestOne
    {
        private const string BaseUrl = "https://api.restful-api.dev";

        //Test Case 01 - Get List Of All Objects
        [Fact]
        public async Task GetListOfAllObjects_ShouldReturnAllObjects()
        {
            // Arrange
            var client = new RestClient(BaseUrl);
            var request = new RestRequest("objects", Method.Get);

            // Act
            var response = await client.ExecuteAsync(request);

            // Assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
            var content = response.Content;

        }

        //Test Case 02 - Get List of objects by its id
        [Fact]
        public async Task GetListOfAllObjectsById_ShouldReturnObjectById()
        {
            // Arrange
            var client = new RestClient(BaseUrl);
            var request = new RestRequest("objects?id=3&id=5&id=10", Method.Get);

            // Act
            var response = await client.ExecuteAsync(request);

            // Assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
            var content = response.Content;
        }

        //Test Case 03 - Retreive Single Object using Id
        [Fact]
        public async Task RetrieveSingleObject_ShouldRetrieveSingleObject()
        {
            // Arrange
            var client = new RestClient(BaseUrl);
            var request = new RestRequest("objects/7", Method.Get);

            // Act
            var response = await client.ExecuteAsync(request);

            // Assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
            var content = response.Content;
        } 

        //Test Case 04 - Add New Object
        [Fact]
        public async Task AddNewObject_ShouldAddNewObject()
        {
            // Arrange
            var client = new RestClient(BaseUrl);
            var request = new RestRequest("objects", Method.Post);
            request.AddJsonBody(new { name = "Apple MacBook Pro 16", year = "2019", price= "1849.99",
                CPUmodel= "Intel Core i9", Harddisksize = "1 TB"});

            // Act
            var response = await client.ExecuteAsync(request);

            // Assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
            var content = response.Content;
        }

        //Test Case 05 - Update object
        [Fact]
        public async Task UpdateObject_ShouldReturnUpdatedObject()
        {
            // Arrange
            var client = new RestClient(BaseUrl);
            var request = new RestRequest("objects/7", Method.Put);
            request.AddJsonBody(new {
                name = "Apple MacBook Pro 16",
                year = "2019",
                price = "2049.99",
                CPUmodel = "Intel Core i9",
                Harddisksize = "1 TB",
                color = "silver"
            });

            // Act
            var response = await client.ExecuteAsync(request);

            // Assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
            var content = response.Content;
        } 

        //Test case 06 - Partially Update Object
        [Fact]
        public async Task UpdateObjectPartially_ShouldReturnUpdatedObjectPartially()
        {
            // Arrange
            var client = new RestClient(BaseUrl);
            var request = new RestRequest("objects/7", Method.Patch);
            request.AddJsonBody(new{name = "Apple MacBook Pro 16 (Updated name)"});

            // Act
            var response = await client.ExecuteAsync(request);

            // Assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
            var content = response.Content;
        }

        //Test Case 07 - Delete Object
        [Fact]
        public async Task DeleteObject_ShouldReturnNoContent()
        {
            // Arrange
            var client = new RestClient(BaseUrl);
            var request = new RestRequest("objects/6", Method.Delete);

            // Act
            var response = await client.ExecuteAsync(request);

            // Assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.NoContent);
        }



    }
}