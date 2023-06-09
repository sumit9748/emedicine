﻿using MedicineShop.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using emedicine.Models;

namespace emedicine.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public UsersController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpPost]
        [Route("register")]
        public Response register(Users users)
        {
            Response response = new Response();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("EMedCS").ToString());
            Userapi userapi=new Userapi();
            response = userapi.register(users, connection);
            return response;
        }
        [HttpPost]
        [Route("login")]
        public Response login(Users users)
        {
            Response response = new Response();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("EMedCS").ToString());
            Userapi userapi = new Userapi();
            response = userapi.register(users, connection);
            return response;
        }
        [HttpGet]
        [Route("viewUser")]
        public Response viewUser(Users users)
        {
            Response response = new Response();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("EMedCS").ToString());
            Userapi userapi = new Userapi();
            response = userapi.viewUser(users, connection);
            return response;
        }
        [HttpGet]
        [Route("viewUserList")]
        public Response viewUserList(Users users)
        {
            Response response = new Response();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("EMedCS").ToString());
            Userapi userapi = new Userapi();
            response = userapi.viewUserList(connection);
            return response;
        }
        [HttpPost]
        [Route("updateProfile")]
        public Response updateProfile(Users users)
        {
            Response response = new Response();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("EMedCS").ToString());
            Userapi userapi = new Userapi();
            response = userapi.updateProfile(users, connection);
            return response;
        }

    }
}
