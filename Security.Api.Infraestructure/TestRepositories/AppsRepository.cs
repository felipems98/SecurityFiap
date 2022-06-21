using Security.Api.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Security.Api.Infraestructure.TestRepositories
{
    public class AppsRepository
    {
        public static List<AppAuth> Get(int AppId)
        {
            var AppAuthInfo = new List<AppAuth>();
            AppAuthInfo.Add(new AppAuth { AppId = 1, Issuer = "00000001-0000-0000-e086-e4b01453da08", Secret = "sEDnt2sojiKlDPqxRTraMoBe1aU88COupzBhuYFpioi7yLKf4TCzff/mBnyfwDnKITUEJjGe9H7TjJpDp+1W5/UxSauUWNpLSuGdeDumurXn6mbysp6ZkLYqMKT8+8lQ/7uhf8022zOBy11STrPNhRO8N+SfC1guJlo0rzmt0WeNmFp37UEmdOlv3K2DZu/0HnyOJ8QJ4v063K1FcP4RcBUkMlAJTX/4l+m93Lz6/g7lt/DMCyc5bVR32G2k/HfSkLWGfjbyGP5y3dqzqn16dYrTZTXa31dL2bt0OB6W/f4PXWVsyEM3BeFZWFZw1mq6YOce5A5QBRH+ZIDV+UDZcw==" });;
           
            return AppAuthInfo.Where(x => x.AppId == AppId).ToList();
        }
    }
}
