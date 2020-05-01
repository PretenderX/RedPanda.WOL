using RedPanda.WOL.Sender;
using System;
using System.Web.UI;

namespace RedPanda.WOL
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnWakeUp_Click(object sender, EventArgs e)
        {
            var mac = new MacAddress { Value = this.macAddress.Text };

            var wolSender = new WOLSender();

            var hasError = !wolSender.Send(mac, out var message);
            
            msgLabel.Text = message;
        }
    }
}