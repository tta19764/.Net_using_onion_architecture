using Microsoft.AspNetCore.Mvc;
using ProgrammingWithPalermo.ChurchBulletin.Core.Model;
using ProgrammingWithPalermo.ChurchBulletin.Core.Queries;

namespace UI.Components.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChurchBulletinItemController : ControllerBase
    {
        private readonly IChurchBulletinItemByDateHandler handler;

        public ChurchBulletinItemController(IChurchBulletinItemByDateHandler handler)
        {
            this.handler = handler;
        }

        [HttpGet]
        public IEnumerable<ChurchBulletinItem> Get()
        {
            IEnumerable<ChurchBulletinItem> items = this.handler.Handle(new ChurchBulletinItemByDateAndTimeQuery(new DateTime(2000, 1, 1, 0, 0, 0, DateTimeKind.Utc)));
            return items;
        }
    }
}
