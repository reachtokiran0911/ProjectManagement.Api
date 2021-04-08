using System;
using Xunit;
using System.Net;
using System.Threading.Tasks;
using ProjectManagement.Api.IntegrationTests.Fixtures;
using System.Text.Json;
using System.Net.Http;
using Newtonsoft.Json;
using ProjectManagement.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectManagement.Api.IntegrationTests
{
    public class ApiIntegrationTest : IClassFixture<ApiWebApplicationFactory<Startup>>
    {
        public HttpClient Client { get; }

        public ApiIntegrationTest(ApiWebApplicationFactory<Startup> factory)
        {
            Client = factory.CreateClient();
        }


        #region Users Test
        [Fact]
        public async Task Get_User_Should_Return_Success()
        {
            //Arrange
            //Act
            var response = await Client.GetAsync("/api/User");
            var stringResponse = await response.Content.ReadAsStringAsync();
            var users = JsonConvert.DeserializeObject<List<User>>(stringResponse);

            //Assert
            Assert.True(users.Count() > 0);
        }

        [Fact]
        public async Task Get_UserById_One_Should_Return_Success()
        {
            //Arrange
            //Act
            var response = await Client.GetAsync("/api/User/1");
            var stringResponse = await response.Content.ReadAsStringAsync();
            var users = JsonConvert.DeserializeObject<User>(stringResponse);

            //Assert
            Assert.Equal(1, users.ID);
        }

        [Fact]
        public async Task Add_New_User_Should_Return_Success()
        {
            //Arrange
            var objPostRequest = new HttpRequestMessage(HttpMethod.Post, "/api/User/");
            User postBody = new User()
            {
                FirstName = "Ramesh",
                LastName = "Kumar",
                Email = "Ramesh.Kumar@gmail.com",
                Password = "Password1",
                ID = 7
            };
            string jsonString = JsonConvert.SerializeObject(postBody);
            objPostRequest.Content = new StringContent(jsonString, Encoding.UTF8, "application/json");

            //Act
            var response = await Client.SendAsync(objPostRequest);
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            var user = JsonConvert.DeserializeObject<User>(responseString);

            //Assert
            Assert.Equal("Ramesh.Kumar@gmail.com", user.Email);
        }

        [Fact]
        public async Task Update_Existing_User_Should_Return_Success()
        {
            //Arrange
            var postRequest = new HttpRequestMessage(HttpMethod.Put, "/api/User/");
            User postBody = new User()
            {
                FirstName = "kiran",
                LastName = "kumar",
                Email = "kiran.kumar1@test.com",
                Password = "Password1",
                ID = 1
            };
            string jsonString = JsonConvert.SerializeObject(postBody);
            postRequest.Content = new StringContent(jsonString, Encoding.UTF8, "application/json");

            //Act
            var response = await Client.SendAsync(postRequest);
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            var user = JsonConvert.DeserializeObject<User>(responseString);

            //Assert
            Assert.Equal("kiran.kumar1@test.com", user.Email);
        }

        [Fact]
        public async Task Delete_Existing_User_Should_Return_Success()
        {
            //Arrange
            var postRequest = new HttpRequestMessage(HttpMethod.Delete, "/api/User?id=5");

            //Act
            var response = await Client.SendAsync(postRequest);

            //Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        #endregion

        #region Tasks Test


        [Fact]
        public async Task Get_TaskById_Should_Return_Success()
        {
            //Act
            var response = await Client.GetAsync("/api/Task/1");
            var stringResponse = await response.Content.ReadAsStringAsync();
            var tasks = JsonConvert.DeserializeObject<Tasks>(stringResponse);

            //Asert
            Assert.Equal(1, tasks.ID);
        }

        [Fact]
        public async Task Get_Task_Should_Return_Success()
        {
            //Act
            var response = await Client.GetAsync("/api/Task");
            var stringResponse = await response.Content.ReadAsStringAsync();
            var Tasks = JsonConvert.DeserializeObject<List<Tasks>>(stringResponse);

            //Assert
            Assert.True(Tasks.Count() > 0);
        }

        [Fact]
        public async Task Add_New_Task_Should_Return_Success()
        {
            //Arrange
            var postRequest = new HttpRequestMessage(HttpMethod.Post, "/api/Task/");
            Tasks postBody = new Tasks()
            {
                ID = 4,
                AssignedToUserID = 2,
                CreatedOn = DateTime.Now,
                Detail = "Test Task 4",
                ProjectID = 2,
                Status = Entities.Enums.TaskStatus.InProgress
            };
            string jsonString = JsonConvert.SerializeObject(postBody);
            postRequest.Content = new StringContent(jsonString, Encoding.UTF8, "application/json");

            //Act
            var response = await Client.SendAsync(postRequest);
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            var tasks = JsonConvert.DeserializeObject<Tasks>(responseString);

            //Assert
            Assert.Equal("Test Task 4", tasks.Detail);
        }

        [Fact]
        public async Task Update_Existing_Task_Should_Return_Success()
        {
            //Arrange
            var postRequest = new HttpRequestMessage(HttpMethod.Put, "/api/Task/");
            Tasks postBody = new Tasks()
            {
                ID = 3,
                AssignedToUserID = 2,
                CreatedOn = DateTime.Now,
                Detail = "Test Task 3 - Updated",
                ProjectID = 2,
                Status = Entities.Enums.TaskStatus.Completed
            };
            string jsonString = JsonConvert.SerializeObject(postBody);
            postRequest.Content = new StringContent(jsonString, Encoding.UTF8, "application/json");

            //Act
            var response = await Client.SendAsync(postRequest);
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            var tasks = JsonConvert.DeserializeObject<Tasks>(responseString);

            //Assert
            Assert.Equal("Test Task 3 - Updated", tasks.Detail);
        }

        [Fact]
        public async Task Delete_Existing_Task_Should_Return_Success()
        {
            //Arange
            var postRequest = new HttpRequestMessage(HttpMethod.Delete, "/api/Task?id=1");

            //Act
            var response = await Client.SendAsync(postRequest);

            //Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        #endregion

        #region Project Tests


        [Fact]
        public async Task Get_ProjectById_Should_Return_Success()
        {
            //Arrange
            //Act
            var response = await Client.GetAsync("/api/Project/1");
            var stringResponse = await response.Content.ReadAsStringAsync();
            var project = JsonConvert.DeserializeObject<Project>(stringResponse);

            //Assert
            Assert.Equal(1, project.ID);
        }

        [Fact]
        public async Task Get_Project_Should_Return_Success()
        {
            //Arrange
            //Act
            var response = await Client.GetAsync("/api/Project");
            var stringResponse = await response.Content.ReadAsStringAsync();
            var project = JsonConvert.DeserializeObject<List<Project>>(stringResponse);

            //Assert
            Assert.True(project.Count() > 0);
        }

        [Fact]
        public async Task Add_New_Project_Should_Return_Success()
        {
            //Arrange
            var postRequest = new HttpRequestMessage(HttpMethod.Post, "/api/Project/");
            Project postBody = new Project()
            {
                ID = 7,
                Name = "Project7",
                CreatedOn = DateTime.Now,
                Detail = "test project 7"
            };
            string jsonString = JsonConvert.SerializeObject(postBody);
            postRequest.Content = new StringContent(jsonString, Encoding.UTF8, "application/json");

            //Act
            var response = await Client.SendAsync(postRequest);
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            var project = JsonConvert.DeserializeObject<Project>(responseString);

            //Assert
            Assert.Equal("Project7", project.Name);
        }

        [Fact]
        public async Task Update_Existing_Project_Should_Return_Success()
        {
            //Arrange
            var postRequest = new HttpRequestMessage(HttpMethod.Put, "/api/Project/");
            Project postBody = new Project()
            {
                ID = 6,
                Name = "Project6",
                CreatedOn = DateTime.Now,
                Detail = "test project 6"
            };
            string jsonString = JsonConvert.SerializeObject(postBody);
            postRequest.Content = new StringContent(jsonString, Encoding.UTF8, "application/json");

            //Act
            var response = await Client.SendAsync(postRequest);
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            var project = JsonConvert.DeserializeObject<Project>(responseString);

            //Assert
            Assert.Equal("Project6", project.Name);
        }

        [Fact]
        public async Task Delete_Existing_Project_Should_Return_Success()
        {
            //Arrange
            var postRequest = new HttpRequestMessage(HttpMethod.Delete, "/api/Project?id=2");

            //Act
            var response = await Client.SendAsync(postRequest);

            //Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

       

        #endregion
    }
}
