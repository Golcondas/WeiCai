﻿/******************************* 
** 作者： nibaoshan 
** 时间： 2018/5/8 17:02:11 
** 版本: V1.0.0 
** CLR: 4.0.30319.42000 
** GUID: 72ebb759-3e6b-48bc-8844-9292f05f4e19 
** 描述： 尚未编写描述 
*******************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using WeiCai.Entity;
using WeiCai.IBLL;

namespace WeiCai.Bll
{
    public partial class UserInfoSerivce : BaseService<userinfo>, IUserInfoService
    {
        public override void SetCurrentDal()
        {
            GetCurrentDal = this.DbSession.GetUserDal;
        }

        public bool DeleteEnities(List<int> list)
        {
            var userInfo = this.DbSession.GetUserDal.LoadEntities(u => list.Contains(u.ID));
            foreach (var item in userInfo)
            {
                this.DbSession.GetUserDal.DeleteByModel(item);
            }
            return this.DbSession.SaveChangesDbSession();
        }

        #region 找回密码
        public void FindUserPwd(userinfo userInfo)
        {
            MailMessage mailMsg = new MailMessage();//两个类，别混了，要引入System.Net这个Assembly
            mailMsg.From = new MailAddress("baoshan@blogneil.top", "neil");//源邮件地址 。发件人地址.
            mailMsg.To.Add(new MailAddress("test@blogneil.top", userInfo.UName));//目的邮件地址。可以有多个收件人
            mailMsg.Subject = "新的账户如下:";//发送邮件的标题 
            StringBuilder sb = new StringBuilder();
            sb.Append("你的新的账户如下:");
            sb.Append("用户名:" + userInfo.UName);
            sb.Append("密码:" + userInfo.UPwd);
            mailMsg.Body = sb.ToString();//发送邮件的内容 
            SmtpClient client = new SmtpClient("smtp.mxhichina.com");//smtp.163.com，smtp.qq.com.发件人的SMTP服务器的地址.
            client.Credentials = new NetworkCredential("baoshan@blogneil.top", "!QAZ3edc");//发件人邮箱的用户和密码.
            client.Send(mailMsg);//排队发送邮件.
        }
        #endregion
    }
}
