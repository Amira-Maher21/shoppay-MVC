﻿using Microsoft.AspNetCore.Identity.UI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.UI.Services;


namespace Utilities
{
	public interface IEmailSender
	{
		Task SendEmailAsync(string email, string subject, string htmlMessage);
	}
}
