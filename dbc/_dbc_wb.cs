using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Data;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using mercury.business;
using Newtonsoft.Json;
using System.IO;

namespace mercury.model
{
    public static class dbc_mercury
    {
        public static List<staff> staffs { get; set; } = new List<staff>();
        public static List<user> users { get; set; } = new List<user>();
        public static List<session> sessions { get; set; } = new List<session>();
        public static List<message> messages { get; set; } = new List<message>();
        public static List<group> groups { get; set; } = new List<group>();
        public static List<group_user> group_users { get; set; } = new List<group_user>();
        public static List<contact> contacts { get; set; } = new List<contact>();
        public static List<chat> chats { get; set; } = new List<chat>();
        public static List<attachment> attachments { get; set; } = new List<attachment>();
        public static List<language> languages { get; set; } = new List<language>();        
        public static List<_const> consts { get; set; } = new List<_const>();
        public static void init()
        {
            DateTime dt = DateTime.Now;
            dbc _dbc = new dbc();
            Console.WriteLine("initing " + _dbc.ds.Count() + " lines started");
            foreach (var _d in _dbc.ds)
            {
                if (_d.flag != 1)
                    continue;
                string _pref = stringify.decrypt(_d.pref, dbc.k);
                if (_pref == attachment.prefix)
                    attachments.Add(JsonConvert.DeserializeObject<attachment>(stringify.decrypt(_d.doc, dbc.k)));
                else if (_pref == session.prefix)
                    sessions.Add(JsonConvert.DeserializeObject<session>(stringify.decrypt(_d.doc, dbc.k)));
                else if (_pref == message.prefix)
                    messages.Add(JsonConvert.DeserializeObject<message>(stringify.decrypt(_d.doc, dbc.k)));
                else if (_pref == group.prefix)
                    groups.Add(JsonConvert.DeserializeObject<group>(stringify.decrypt(_d.doc, dbc.k)));
                else if (_pref == user.prefix)
                    users.Add(JsonConvert.DeserializeObject<user>(stringify.decrypt(_d.doc, dbc.k)));
                else if (_pref == staff.prefix)
                    staffs.Add(JsonConvert.DeserializeObject<staff>(stringify.decrypt(_d.doc, dbc.k)));
                else if (_pref == group_user.prefix)
                    group_users.Add(JsonConvert.DeserializeObject<group_user>(stringify.decrypt(_d.doc, dbc.k)));
                else if (_pref == contact.prefix)
                    contacts.Add(JsonConvert.DeserializeObject<contact>(stringify.decrypt(_d.doc, dbc.k)));
                else if (_pref == chat.prefix)
                    chats.Add(JsonConvert.DeserializeObject<chat>(stringify.decrypt(_d.doc, dbc.k)));
                else if (_pref == _const.prefix)
                    consts.Add(JsonConvert.DeserializeObject<_const>(stringify.decrypt(_d.doc, dbc.k)));
            }
            Console.WriteLine(_dbc.ds.Count() + " lines inited at -> " + (DateTime.Now - dt).TotalSeconds.ToString() + " seconds");
        }
    }
    public class dbc : DbContext
    {
        public DbSet<d> ds { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            try
            {
                //optionsBuilder.UseMySQL(_io._config_value("db_cnn_1"));
                optionsBuilder.UseSqlite("Data Source=" + Directory.GetCurrentDirectory() + "/db.db" + ";");
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("[-_-] : " + ex);
            }
        }
        public const string k = "a temp const key, later will be dynamic! haha";
        static Stack<d> docs_insert = new Stack<d>();
        public static int insert(object doc)
        {
            //dbc _dbc = new dbc();
            d _d = new d();
            _d.doc = stringify.encrypt(JsonConvert.SerializeObject(doc), k);
            _d.pref = doc.GetType().GetProperty("prefix").GetValue(doc).ToString();
            _d.pref = stringify.encrypt(_d.pref, k);
            _d.suff = doc.GetType().GetProperty("id").GetValue(doc).ToString();
            //_dbc.ds.Add(_d);
            //_dbc.SaveChanges();
            docs_insert.Push(_d);

            return (int)_d.id;
        }
        public static async void live()
        {
            dbc _dbc = new dbc();
            if (docs_insert.Count() > 0)
            {
                while (docs_insert.Count() > 0)
                {
                    d _d = docs_insert.Pop();
                    _dbc.ds.Add(_d);
                }
                _dbc.SaveChanges();
            }
            await Task.Delay(100);
            live();
        }
        public static long update(object doc)
        {
            dbc _dbc = new dbc();

            string pref = doc.GetType().GetProperty("prefix").GetValue(doc).ToString();
            pref = stringify.encrypt(pref, k);
            string suff = doc.GetType().GetProperty("id").GetValue(doc).ToString();
            d _d = _dbc.ds.Where(x => x.pref == pref && x.suff == suff).FirstOrDefault();
            if (_d == null)
                return -1;
            _d.doc = stringify.encrypt(JsonConvert.SerializeObject(doc), k);
            _dbc.SaveChanges();
            return _d.id;
        }

        public static bool delete(object doc)
        {
            dbc _dbc = new dbc();
            string pref = doc.GetType().GetProperty("prefix").GetValue(doc).ToString();
            pref = stringify.encrypt(pref, k);
            string suff = doc.GetType().GetProperty("id").GetValue(doc).ToString();
            d _d = _dbc.ds.Where(x => x.pref == pref && x.suff == suff).FirstOrDefault();
            if (_d == null)
                return false;
            _dbc.ds.Remove(_d);
            _dbc.SaveChanges();
            return true;
        }

        [Table("d")]
        public class d
        {
            public long id { set; get; }
            public string pref { set; get; }
            public string suff { set; get; }
            public int flag { set; get; } = 1;
            public string doc { set; get; }
        }

    }
}