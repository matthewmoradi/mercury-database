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
using mercury.business;
using mercury.model;

namespace mercury.controller
{
    public partial class ctrl_xhr : Controller
    {
        #region get
        protected List<user> get_users(Dictionary<string, string> parameters)
        {
            return dbc_mercury.users.ToList();
        }
        protected List<staff> get_staffs(Dictionary<string, string> parameters)
        {
            return dbc_mercury.staffs.ToList();
        }
        protected List<session> get_sessions(Dictionary<string, string> parameters)
        {
            return dbc_mercury.sessions.ToList();
        }
        protected List<message> get_messages(Dictionary<string, string> parameters)
        {
            return dbc_mercury.messages.ToList();
        }
        protected List<group> get_groups(Dictionary<string, string> parameters)
        {
            return dbc_mercury.groups.ToList();
        }
        protected List<group_user> get_group_users(Dictionary<string, string> parameters)
        {
            return dbc_mercury.group_users.ToList();
        }
        protected List<contact> get_contacts(Dictionary<string, string> parameters)
        {
            return dbc_mercury.contacts.ToList();
        }
        protected List<chat> get_chats(Dictionary<string, string> parameters)
        {
            return dbc_mercury.chats.ToList();
        }
        protected List<attachment> get_attachments(Dictionary<string, string> parameters)
        {
            return dbc_mercury.attachments.ToList();
        }
        protected List<language> get_languages(Dictionary<string, string> parameters)
        {
            return dbc_mercury.languages.ToList();
        }
        #endregion get
        // 
        #region update
        protected user update_user(Dictionary<string, string> parameters)
        {
            var item_new = JsonConvert.DeserializeObject<user>(parameters["user"]);
            var item = dbc_mercury.users.FirstOrDefault(x => x.id == item_new.id);
            if (item == null)
                return null;
            dbc_mercury.users.Remove(item);
            dbc_mercury.users.Add(item_new);
            dbc.update(item_new);
            return item_new;
        }
        protected staff update_staff(Dictionary<string, string> parameters)
        {
            var item_new = JsonConvert.DeserializeObject<staff>(parameters["staff"]);
            var item = dbc_mercury.staffs.FirstOrDefault(x => x.id == item_new.id);
            if (item == null)
                return null;
            dbc_mercury.staffs.Remove(item);
            dbc_mercury.staffs.Add(item_new);
            dbc.update(item);
            return item;
        }
        protected session update_session(Dictionary<string, string> parameters)
        {
            var item_new = JsonConvert.DeserializeObject<session>(parameters["session"]);
            var item = dbc_mercury.sessions.FirstOrDefault(x => x.id == item_new.id);
            dbc_mercury.sessions.Remove(item);
            dbc_mercury.sessions.Add(item_new);
            dbc.update(item);
            return item;
        }
        protected message update_message(Dictionary<string, string> parameters)
        {
            var item_new = JsonConvert.DeserializeObject<message>(parameters["message"]);
            var item = dbc_mercury.messages.FirstOrDefault(x => x.id == item_new.id);
            if (item == null)
                return null;
            dbc_mercury.messages.Remove(item);
            dbc_mercury.messages.Add(item_new);
            dbc.update(item);
            return item;
        }
        protected group update_group(Dictionary<string, string> parameters)
        {
            var item_new = JsonConvert.DeserializeObject<group>(parameters["group"]);
            var item = dbc_mercury.groups.FirstOrDefault(x => x.id == item_new.id);
            if (item == null)
                return null;
            dbc_mercury.groups.Remove(item);
            dbc_mercury.groups.Add(item_new);
            dbc.update(item);
            return item;
        }
        protected group_user update_group_user(Dictionary<string, string> parameters)
        {
            var item_new = JsonConvert.DeserializeObject<group_user>(parameters["group"]);
            var item = dbc_mercury.group_users.FirstOrDefault(x => x.id == item_new.id);
            if (item == null)
                return null;
            dbc_mercury.group_users.Remove(item);
            dbc_mercury.group_users.Add(item_new);
            dbc.update(item);
            return item;
        }
        protected contact update_contact(Dictionary<string, string> parameters)
        {
            var item_new = JsonConvert.DeserializeObject<contact>(parameters["contact"]);
            var item = dbc_mercury.contacts.FirstOrDefault(x => x.id == item_new.id);
            if (item == null)
                return null;
            dbc_mercury.contacts.Remove(item);
            dbc_mercury.contacts.Add(item_new);
            dbc.update(item);
            return item;
        }
        protected chat update_chat(Dictionary<string, string> parameters)
        {
            var item_new = JsonConvert.DeserializeObject<chat>(parameters["chat"]);
            var item = dbc_mercury.chats.FirstOrDefault(x => x.id == item_new.id);
            if (item == null)
                return null;
            dbc_mercury.chats.Remove(item);
            dbc_mercury.chats.Add(item_new);
            dbc.update(item);
            return item;
        }
        protected attachment update_attachment(Dictionary<string, string> parameters)
        {
            var item_new = JsonConvert.DeserializeObject<attachment>(parameters["attachment"]);
            var item = dbc_mercury.attachments.FirstOrDefault(x => x.id == item_new.id);
            if (item == null)
                return null;
            dbc_mercury.attachments.Remove(item);
            dbc_mercury.attachments.Add(item_new);
            dbc.update(item);
            return item;
        }
        protected language update_language(Dictionary<string, string> parameters)
        {
            var item_new = JsonConvert.DeserializeObject<language>(parameters["language"]);
            var item = dbc_mercury.languages.FirstOrDefault(x => x.id == item_new.id);
            if (item == null)
                return null;
            dbc_mercury.languages.Remove(item);
            dbc_mercury.languages.Add(item_new);
            dbc.update(item);
            return item;
        }
        #endregion update
        // 
        #region insert
        protected user insert_user(Dictionary<string, string> parameters)
        {
            var item_new = JsonConvert.DeserializeObject<user>(parameters["user"]);
            var item = dbc_mercury.users.FirstOrDefault(x => x.id == item_new.id);
            if (item != null)
                return null;
            dbc_mercury.users.Add(item_new);
            dbc.insert(item_new);
            return item;
        }
        protected staff insert_staff(Dictionary<string, string> parameters)
        {
            var item_new = JsonConvert.DeserializeObject<staff>(parameters["staff"]);
            var item = dbc_mercury.staffs.FirstOrDefault(x => x.id == item_new.id);
            if (item != null)
                return null;
            dbc_mercury.staffs.Add(item_new);
            dbc.insert(item_new);
            return item;
        }
        protected session insert_session(Dictionary<string, string> parameters)
        {
            var item_new = JsonConvert.DeserializeObject<session>(parameters["session"]);
            var item = dbc_mercury.sessions.FirstOrDefault(x => x.id == item_new.id);
            if (item != null)
                return null;
            dbc_mercury.sessions.Add(item_new);
            dbc.insert(item_new);
            return item;
        }
        protected message insert_message(Dictionary<string, string> parameters)
        {
            var item_new = JsonConvert.DeserializeObject<message>(parameters["message"]);
            var item = dbc_mercury.messages.FirstOrDefault(x => x.id == item_new.id);
            if (item != null)
                return null;
            dbc_mercury.messages.Add(item_new);
            dbc.insert(item_new);
            return item;
        }
        protected group insert_group(Dictionary<string, string> parameters)
        {
            var item_new = JsonConvert.DeserializeObject<group>(parameters["group"]);
            var item = dbc_mercury.groups.FirstOrDefault(x => x.id == item_new.id);
            if (item != null)
                return null;
            dbc_mercury.groups.Add(item_new);
            dbc.insert(item_new);
            return item;
        }
        protected group_user insert_group_user(Dictionary<string, string> parameters)
        {
            var item_new = JsonConvert.DeserializeObject<group_user>(parameters["group_user"]);
            var item = dbc_mercury.group_users.FirstOrDefault(x => x.id == item_new.id);
            if (item != null)
                return null;
            dbc_mercury.group_users.Add(item_new);
            dbc.insert(item_new);
            return item;
        }
        protected contact insert_contact(Dictionary<string, string> parameters)
        {
            var item_new = JsonConvert.DeserializeObject<contact>(parameters["contact"]);
            var item = dbc_mercury.contacts.FirstOrDefault(x => x.id == item_new.id);
            if (item != null)
                return null;
            dbc_mercury.contacts.Add(item_new);
            dbc.insert(item_new);
            return item;
        }
        protected chat insert_chat(Dictionary<string, string> parameters)
        {
            var item_new = JsonConvert.DeserializeObject<chat>(parameters["chat"]);
            var item = dbc_mercury.chats.FirstOrDefault(x => x.id == item_new.id);
            if (item != null)
                return null;
            dbc_mercury.chats.Add(item_new);
            dbc.insert(item_new);
            return item;
        }
        protected attachment insert_attachment(Dictionary<string, string> parameters)
        {
            var item_new = JsonConvert.DeserializeObject<attachment>(parameters["attachment"]);
            var item = dbc_mercury.attachments.FirstOrDefault(x => x.id == item_new.id);
            if (item != null)
                return null;
            dbc_mercury.attachments.Add(item_new);
            dbc.insert(item_new);
            return item;
        }
        protected language insert_language(Dictionary<string, string> parameters)
        {
            var item_new = JsonConvert.DeserializeObject<language>(parameters["language"]);
            var item = dbc_mercury.languages.FirstOrDefault(x => x.id == item_new.id);
            if (item != null)
                return null;
            dbc_mercury.languages.Add(item_new);
            dbc.insert(item_new);
            return item;
        }
        #endregion insert
        // 
        #region delete
        protected bool delete_user(Dictionary<string, string> parameters)
        {
            var item_new = JsonConvert.DeserializeObject<user>(parameters["user"]);
            var item = dbc_mercury.users.FirstOrDefault(x => x.id == item_new.id);
            if (item == null)
                return false;
            dbc_mercury.users.Remove(item);
            dbc.delete(item);
            return true;
        }
        protected bool delete_staff(Dictionary<string, string> parameters)
        {
            var item_new = JsonConvert.DeserializeObject<staff>(parameters["staff"]);
            var item = dbc_mercury.staffs.FirstOrDefault(x => x.id == item_new.id);
            if (item == null)
                return false;
            dbc_mercury.staffs.Remove(item);
            dbc.delete(item);
            return true;
        }
        protected bool delete_session(Dictionary<string, string> parameters)
        {
            var item_new = JsonConvert.DeserializeObject<session>(parameters["session"]);
            var item = dbc_mercury.sessions.FirstOrDefault(x => x.id == item_new.id);
            if (item == null)
                return false;
            dbc_mercury.sessions.Remove(item);
            dbc.delete(item);
            return true;
        }
        protected bool delete_message(Dictionary<string, string> parameters)
        {
            var item_new = JsonConvert.DeserializeObject<message>(parameters["message"]);
            var item = dbc_mercury.messages.FirstOrDefault(x => x.id == item_new.id);
            if (item == null)
                return false;
            dbc_mercury.messages.Remove(item);
            dbc.delete(item);
            return true;
        }
        protected bool delete_group(Dictionary<string, string> parameters)
        {
            var item_new = JsonConvert.DeserializeObject<group>(parameters["group"]);
            var item = dbc_mercury.groups.FirstOrDefault(x => x.id == item_new.id);
            if (item == null)
                return false;
            dbc_mercury.groups.Remove(item);
            dbc.delete(item);
            return true;
        }
        protected bool delete_group_user(Dictionary<string, string> parameters)
        {
            var item_new = JsonConvert.DeserializeObject<group_user>(parameters["group_user"]);
            var item = dbc_mercury.group_users.FirstOrDefault(x => x.id == item_new.id);
            if (item == null)
                return false;
            dbc_mercury.group_users.Remove(item);
            dbc.delete(item);
            return true;
        }
        protected bool delete_contact(Dictionary<string, string> parameters)
        {
            var item_new = JsonConvert.DeserializeObject<contact>(parameters["contact"]);
            var item = dbc_mercury.contacts.FirstOrDefault(x => x.id == item_new.id);
            if (item == null)
                return false;
            dbc_mercury.contacts.Remove(item);
            dbc.delete(item);
            return true;
        }
        protected bool delete_chat(Dictionary<string, string> parameters)
        {
            var item_new = JsonConvert.DeserializeObject<chat>(parameters["chat"]);
            var item = dbc_mercury.chats.FirstOrDefault(x => x.id == item_new.id);
            if (item == null)
                return false;
            dbc_mercury.chats.Remove(item);
            dbc.delete(item);
            return true;
        }
        protected bool delete_attachment(Dictionary<string, string> parameters)
        {
            var item_new = JsonConvert.DeserializeObject<attachment>(parameters["attachment"]);
            var item = dbc_mercury.attachments.FirstOrDefault(x => x.id == item_new.id);
            if (item == null)
                return false;
            dbc_mercury.attachments.Remove(item);
            dbc.delete(item);
            return true;
        }
        protected bool delete_language(Dictionary<string, string> parameters)
        {
            var item_new = JsonConvert.DeserializeObject<language>(parameters["language"]);
            var item = dbc_mercury.languages.FirstOrDefault(x => x.id == item_new.id);
            if (item == null)
                return false;
            dbc_mercury.languages.Remove(item);
            dbc.delete(item);
            return true;
        }
        #endregion delete
    }
}