﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using TheBigEvent.Authentification;
using TheBigEvent.Services;
using TheBigEvent.Models;
using TheBigEvent.DAL;
using MailKit.Net.Smtp;
using MimeKit;
using MailKit.Security;


// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace TheBigEvent.Controllers
{
    [Route("api/[controller]")]
    [Authorize(ActiveAuthenticationSchemes = JwtBearerAuthentication.AuthenticationScheme)]
    public class BigSelecteController : Controller
    {
        // GET: /<controller>/
        readonly BigSelecteService _bigselecteService;
        readonly InviteService _inviteService;
        readonly DateService _dateService;
        readonly ValidationService _validationService;

        public BigSelecteController(BigSelecteService bigselecteservice, InviteService inviteservice, DateService dateservice, ValidationService validationservice)
        {
            _bigselecteService = bigselecteservice;
            _inviteService = inviteservice;
            _dateService = dateservice;
            _validationService = validationservice;
        }

        [HttpPost("createBigSelect/")]
        public Result<BigSelecte> createBigSelect([FromBody] BigSelecteViewModels model)
        {
            return _bigselecteService.addBigSelecte( model.UserId, model.Nom, model.Ville, model.Description);
        }
        [HttpPost("createInvite/")]
        public async void createInvite([FromBody] InviteViewModels model)
        {
            _inviteService.addInvite(model.BigSelecteId, model.Nom, model.Mail);

            string _subject = "Invitation a un evenement";
            string _message = "Voici votre code";
            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress("thebigevent", "TheBigEventPi@gmail.com"));
            emailMessage.To.Add(new MailboxAddress("", model.Mail));
            emailMessage.Subject = _subject;
            emailMessage.Body = new TextPart("plain") { Text = _message };

            //using (var client = new SmtpClient())
            //{
            //    client.LocalDomain = "gmail.com";
            //    await client.ConnectAsync("smtp.gmail.com", 25, SecureSocketOptions.None).ConfigureAwait(false);
            //    await client.SendAsync(emailMessage).ConfigureAwait(false);
            //    await client.DisconnectAsync(true).ConfigureAwait(false);
            //}
            using (var client = new SmtpClient())
            {
                client.Connect("aspmx.l.google.com", 25, false);
                client.AuthenticationMechanisms.Remove("XOAUTH2");
                // Note: since we don't have an OAuth2 token, disable 	// the XOAUTH2 authentication mechanism.     client.Authenticate("anuraj.p@example.com", "password");
                client.Send(emailMessage);
                client.Disconnect(true);
            }

        }
        [HttpPost("createDate/")]
        public void createDate([FromBody] DateViewModels model)
        {
            _dateService.addDate(model.Dates, model.BigSelecteId);
        }
        [HttpPost("createValidation/")]
        public void createValidation([FromBody] ValidationViewModels model)
        {
            _validationService.addValidation(model.PropositionId, model.ValidationId);
        }
    }
}
