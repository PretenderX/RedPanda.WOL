using Derungsoft.WolSharp;
using System;

namespace RedPanda.WOL.Sender
{
    public class WOLSender
    {
        public bool Send(MacAddress macAddress, out string message)
        {
            if (string.IsNullOrEmpty(macAddress.Value))
            {
                message = "MAC地址不能为空！";
                return false;
            }

            if (macAddress.Value.Contains(":"))
            {
                macAddress.Value = macAddress.Value.Replace(":", "-");
            }

            if (macAddress.Value.Split('-').Length != 6)
            {
                message = "MAC地址格式错误！";
                return false;
            }

            var awakener = new Awakener();

            try
            {
                awakener.Wake(macAddress.Value);
            }
            catch (Exception ex)
            {
                message = ex.Message;

                return false;
            }

            message = "唤醒指令发送成功！";
            return true;
        }
    }
}
