using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WidServiceInstaller
{
    public class DeploymentConfig
    {
        [DisplayName("Базовий фолдер сервісу реплікації WID")]
        [Category("UcGeneralSettings")]
        public string DeploymentRootPath { get; set; }
        [DisplayName("Обліковий запис сервісу реплікації WID")]
        [Category("UcGeneralSettings")]
        public string WindowsServiceAccount { get; set; }

        [DisplayName("URL FTP-серверу WID")]
        [Category("UcWidFtpSettings")]
        public string WidFtpUrl { get; set; }
        [DisplayName("Логін FTP-серверу WID")]
        [Category("UcWidFtpSettings")]
        public string WidFtpLogin { get; set; }
        [DisplayName("Пароль FTP-серверу WID")]
        [Category("UcWidFtpSettings")]
        public string WidFtpPassword { get; set; }

        [DisplayName("URL FTP-серверу IPI")]
        [Category("UcIpiFtpSettings")]
        public string IpiFtpUrl { get; set; }
        [DisplayName("Логін FTP-серверу IPI")]
        [Category("UcIpiFtpSettings")]
        public string IpiFtpLogin { get; set; }
        [DisplayName("Пароль FTP-серверу IPI")]
        [Category("UcIpiFtpSettings")]
        public string IpiFtpPassword { get; set; }

        [DisplayName("Сервер баз даних для реплікації")]
        [Category("UcDatabaseSettings")]
        public string DbServerUrl { get; set; }
        [DisplayName("Логін сервера баз даних для реплікації")]
        [Category("UcDatabaseSettings")]
        public string DbServerLogin { get; set; }
        [DisplayName("Пароль сервера баз даних для реплікації")]
        [Category("UcDatabaseSettings")]
        public string DbServerPassword { get; set; }

        public DeploymentConfig()
        {
            DeploymentRootPath = @"d:\UACRR\WID";
            WindowsServiceAccount = "Local System";

            WidFtpUrl = "ftp://ftp-aws.fasttrackdcn.net";
            WidFtpLogin = "wid_140";
            WidFtpPassword = "ad1WropKoPhlyb";

            IpiFtpUrl = "ftp://ftp.suisa.ch";
            IpiFtpLogin = "UACRR";
            IpiFtpPassword = "0RvLrb0M";

            DbServerUrl = @"89.184.65.168\IPSDATA,60675";
            DbServerLogin = "WidReplicationService";
            DbServerPassword = "WidReplicationServicePwd";
    }
    }
}
