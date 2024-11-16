using Social_network.Models;
using Social_network.request;
using Social_network.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Social_network.Repository
{
    interface CommentRepository
    {
		Task<List<CommentResponse>> getAllcmtByPostId(PageInfo pageInfo, long id);
		Task<string> addComment(CommentRequest commentRequest, long postId);
		string deleteComment(long cmtId);
	}
}
