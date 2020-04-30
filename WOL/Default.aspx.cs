using Derungsoft.WolSharp;
using System;
using System.Web.UI;

namespace WOL
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnWakeUp_Click(object sender, EventArgs e)
        {
            var macAddress = this.macAddress.Text;

            if (string.IsNullOrEmpty(macAddress))
            {
                msgLabel.Text = "MAC地址不能为空！";

                return;
            }

            if (macAddress.Contains(":"))
            {
                macAddress = macAddress.Replace(":", "-");
            }

            if (macAddress.Split('-').Length != 6)
            {
                msgLabel.Text = "MAC地址格式错误！";

                return;
            }

            var awakener = new Awakener();

            awakener.Wake(macAddress);

            msgLabel.Text = "唤醒指令发送成功！";
        }
    }
}