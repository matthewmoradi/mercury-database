using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Cors;
using System.IO;
using System.Text;
using System.Collections.Generic;
using Newtonsoft.Json;
using mercury.model;
using mercury.business;

namespace mercury.controller
{
    public partial class ctrl_xhr : Controller
    {
        private Dictionary<string, string> decode_parameters(string body)
        {
            // decryption
            Dictionary<string, string> parameters = JsonConvert.DeserializeObject<Dictionary<string, string>>(body);
            return parameters;
        }
        private bool contains(Dictionary<string, string> dic, string[] keys)
        {
            foreach (var key in keys)
                if (!dic.ContainsKey(key))
                    return false;
            return true;
        }
        private ActionResult ret(staff _staff, dto.msg obj)
        {
            string serd = JsonConvert.SerializeObject(obj);
            string ret = Convert.ToBase64String(Encoding.UTF8.GetBytes(serd));
            // Console.WriteLine("Response Len: " + ret.Length);
            return Content(ret);
        }
        private ActionResult ret(dto.msg obj)
        {
            string serd = JsonConvert.SerializeObject(obj);
            // Console.WriteLine("Response Len: " + ret.Length);
            return Content(serd);
        }
        private ActionResult ret(object data)
        {
            string data_str = "";
            if (data != null)
                data_str = JsonConvert.SerializeObject(data);
            var res = new dto.msg(dto.msg.response_code_valid, message_sys.success, data_str, true);
            return ret(res);
        }

        [Route("{*url}")]
        public IActionResult error(string code)
        {
            return Content("What are you looking for? Heh!");
        }
        // 
        [HttpPost]
        [EnableCors("cors_mercury")]
        [Route("/get")]
        public IActionResult get()
        {
            string body = new StreamReader(HttpContext.Request.Body, Encoding.UTF8, true, 1024, true).ReadToEnd();
            var parameters = decode_parameters(body);
            if (!contains(parameters, new string[] { "token", "action" }))
            {
                return ret(new dto.msg(dto.msg.response_code_logout, message_sys.wrong_parameters, "", false));
            }
            var token = parameters["token"];
            if (token != _io._config_value("token_database"))
            {
                _sys.log(new Exception("Unauthenticated access")); // log IP and other info as well
                return ret(new dto.msg(dto.msg.response_code_logout, message_sys.NOT_AUTHED, "", false));
            }
            return parameters["action"] switch
            {
                "staffs" => ret(get_staffs(parameters)),
                "users" => ret(get_users(parameters)),
                "sessions" => ret(get_sessions(parameters)),
                "messages" => ret(get_messages(parameters)),
                "groups" => ret(get_groups(parameters)),
                "group_users" => ret(get_group_users(parameters)),
                "contacts" => ret(get_contacts(parameters)),
                "chats" => ret(get_chats(parameters)),
                "attachments" => ret(get_attachments(parameters)),
                "languages" => ret(get_languages(parameters)),
                _ => ret(new dto.msg(dto.msg.response_code_valid, message_sys.action_not_found, "", false)),
            };
        }
        // 
        [HttpPost]
        [EnableCors("cors_mercury")]
        [Route("/update")]
        public IActionResult update()
        {
            string body = new StreamReader(HttpContext.Request.Body, Encoding.UTF8, true, 1024, true).ReadToEnd();
            var parameters = decode_parameters(body);
            if (!contains(parameters, new string[] { "token", "action" }))
            {
                return ret(new dto.msg(dto.msg.response_code_logout, message_sys.wrong_parameters, "", false));
            }
            var token = parameters["token"];
            if (token != _io._config_value("token_database"))
            {
                _sys.log(new Exception("Unauthenticated access")); // log IP and other info as well
                return ret(new dto.msg(dto.msg.response_code_logout, message_sys.NOT_AUTHED, "", false));
            }
            // 
            return parameters["action"] switch
            {
                "staffs" => ret(update_staff(parameters)),
                "users" => ret(update_user(parameters)),
                "sessions" => ret(update_session(parameters)),
                "messages" => ret(update_message(parameters)),
                "groups" => ret(update_group(parameters)),
                "group_users" => ret(update_group_user(parameters)),
                "contacts" => ret(update_contact(parameters)),
                "chats" => ret(update_chat(parameters)),
                "attachments" => ret(update_attachment(parameters)),
                "languages" => ret(update_language(parameters)),
                _ => ret(new dto.msg(dto.msg.response_code_valid, message_sys.action_not_found, "", false)),
            };
        }
        // 
        [HttpPost]
        [EnableCors("cors_mercury")]
        [Route("/insert")]
        public IActionResult insert()
        {
            string body = new StreamReader(HttpContext.Request.Body, Encoding.UTF8, true, 1024, true).ReadToEnd();
            var parameters = decode_parameters(body);
            if (!contains(parameters, new string[] { "token", "action" }))
            {
                return ret(new dto.msg(dto.msg.response_code_logout, message_sys.wrong_parameters, "", false));
            }
            var token = parameters["token"];
            if (token != _io._config_value("token_database"))
            {
                _sys.log(new Exception("Unauthenticated access")); // log IP and other info as well
                return ret(new dto.msg(dto.msg.response_code_logout, message_sys.NOT_AUTHED, "", false));
            }
            // 
            return parameters["action"] switch
            {
                "staffs" => ret(insert_staff(parameters)),
                "users" => ret(insert_user(parameters)),
                "sessions" => ret(insert_session(parameters)),
                "messages" => ret(insert_message(parameters)),
                "groups" => ret(insert_group(parameters)),
                "group_users" => ret(insert_group_user(parameters)),
                "contacts" => ret(insert_contact(parameters)),
                "chats" => ret(insert_chat(parameters)),
                "attachments" => ret(insert_attachment(parameters)),
                "languages" => ret(insert_language(parameters)),
                _ => ret(new dto.msg(dto.msg.response_code_valid, message_sys.action_not_found, "", false)),
            };
        }
        // 
        [HttpPost]
        [EnableCors("cors_mercury")]
        [Route("/delete")]
        public IActionResult delete()
        {
            string body = new StreamReader(HttpContext.Request.Body, Encoding.UTF8, true, 1024, true).ReadToEnd();
            var parameters = decode_parameters(body);
            if (!contains(parameters, new string[] { "token", "action" }))
            {
                return ret(new dto.msg(dto.msg.response_code_logout, message_sys.wrong_parameters, "", false));
            }
            var token = parameters["token"];
            if (token != _io._config_value("token_database"))
            {
                _sys.log(new Exception("Unauthenticated access")); // log IP and other info as well
                return ret(new dto.msg(dto.msg.response_code_logout, message_sys.NOT_AUTHED, "", false));
            }
            // 
            return parameters["action"] switch
            {
                "staffs" => ret(delete_staff(parameters)),
                "users" => ret(delete_user(parameters)),
                "sessions" => ret(delete_session(parameters)),
                "messages" => ret(delete_message(parameters)),
                "groups" => ret(delete_group(parameters)),
                "group_users" => ret(delete_group_user(parameters)),
                "contacts" => ret(delete_contact(parameters)),
                "chats" => ret(delete_chat(parameters)),
                "attachments" => ret(delete_attachment(parameters)),
                "languages" => ret(delete_language(parameters)),
                _ => ret(new dto.msg(dto.msg.response_code_valid, message_sys.action_not_found, "", false)),
            };
        }
    }
}