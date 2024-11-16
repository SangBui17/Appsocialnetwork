using Social_network.Models;
using Social_network.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Social_network.Repository
{
    interface PostRepository
    {
        Task<List<PostResponse>> getAllPost(PageInfo pageinfo);
	}
}
