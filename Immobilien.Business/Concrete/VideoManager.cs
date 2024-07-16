using Immobilien.Business.Abstract;
using Immobilien.DataAccess.Abstract;
using Immobilien.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Immobilien.Business.Concrete
{
    public class VideoManager : GenericManager<Video>, IVideoService
    {
        public VideoManager(IGenericDal<Video> genericDal) : base(genericDal)
        {
        }
    }
}
