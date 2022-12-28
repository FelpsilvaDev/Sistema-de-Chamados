using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
//using ActiveDs;
using System.Runtime.InteropServices;
using System.Configuration;

namespace Entidades
{
    public class EnviaEmail
    {
        private string nome;
        public string buscarEmailUser(string displayName)
        {
       
                DirectoryEntry er = new DirectoryEntry("LDAP://SRVJDIAD01.CMR.COM.BR", "administrator", "(#L1&20==)");

                DirectorySearcher pesquisa = new DirectorySearcher();

                pesquisa.SearchRoot = er;
                pesquisa.SearchScope = SearchScope.Subtree;
                pesquisa.Filter = "(ObjectClass=user)";
                pesquisa.Filter = "(&(ObjectClass=user)(displayname=" + displayName + "))";

                foreach (SearchResult result in pesquisa.FindAll())
                {
                    nome = result.Properties["mail"][0].ToString();
                }

                return nome;
         
            
        }



        public void EnviarEmail(string EmailClient, string assunto, string corpoEmail)
        {

            // Instancia a classe Para envio de email
            MailMessage email = new MailMessage();
            // Emitente do email
            email.From = new MailAddress(ConfigurationManager.AppSettings["Usuario_Email_Suporte"].ToString(), "CMR - Service Desk");
            // Destinatário
            string[] Destinatarios = new string[2];

            Destinatarios[0] = ConfigurationManager.AppSettings["Usuario_Email_Suporte"].ToString();
            Destinatarios[1] = EmailClient;


            foreach (string item in Destinatarios)
            {
                email.To.Add(item);
            }
            // Cópia
            // email.CC.Add("suporte_ti@cmrcia.com.br");



            // Prioridade
            //email.Priority = MailPriority.High;

            //Assunto
            email.Subject = assunto;

            // Informa que o corpo é do Tipo Html
            // email.IsBodyHtml = true;
            // Corpo da Página
            email.Body = corpoEmail;

            // informa o servidor smtp
            SmtpClient smtp = new SmtpClient();

            smtp.Host = "smtp.office365.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.Timeout = 20000;


            //smtp.Host = "smtp.gmail.com";
            //smtp.Port = 587;
            //smtp.EnableSsl = true;

            smtp.Credentials = new NetworkCredential(ConfigurationManager.AppSettings["Usuario_Email_Suporte"].ToString(), ConfigurationManager.AppSettings["Senha_Email_Suporte"].ToString());
            // envia o email
            try
            {
                smtp.Send(email);
                smtp.Dispose();
            }
            catch (Exception)
            {


            }

        }

        public void EnviarEmail(string Emailgestor , string EmailClient, string assunto, string corpoEmail)
        {

            // Instancia a classe Para envio de email
            MailMessage email = new MailMessage();
            // Emitente do email
            email.From = new MailAddress(ConfigurationManager.AppSettings["Usuario_Email_Suporte"].ToString(), "CMR - Service Desk");
            // Destinatário
            string[] Destinatarios = new string[3];

            Destinatarios[0] = ConfigurationManager.AppSettings["Usuario_Email_Suporte"].ToString();
            Destinatarios[1] = EmailClient;
            Destinatarios[2] = Emailgestor;


            foreach (string item in Destinatarios)
            {
                email.To.Add(item);
            }
            // Cópia
            // email.CC.Add("suporte_ti@cmrcia.com.br");



            // Prioridade
            //email.Priority = MailPriority.High;

            //Assunto
            email.Subject = assunto;

            // Informa que o corpo é do Tipo Html
            // email.IsBodyHtml = true;
            // Corpo da Página
            email.Body = corpoEmail;

            // informa o servidor smtp
            SmtpClient smtp = new SmtpClient();

            smtp.Host = "smtp.office365.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.Timeout = 20000;


            //smtp.Host = "smtp.gmail.com";
            //smtp.Port = 587;
            //smtp.EnableSsl = true;

            smtp.Credentials = new NetworkCredential(ConfigurationManager.AppSettings["Usuario_Email_Suporte"].ToString(), ConfigurationManager.AppSettings["Senha_Email_Suporte"].ToString());
            // envia o email
            try
            {
                smtp.Send(email);
                smtp.Dispose();
            }
            catch (Exception ex)
            {
                throw;
            }

        }  
    }
}
