; ModuleID = 'marshal_methods.x86.ll'
source_filename = "marshal_methods.x86.ll"
target datalayout = "e-m:e-p:32:32-p270:32:32-p271:32:32-p272:64:64-f64:32:64-f80:32-n8:16:32-S128"
target triple = "i686-unknown-linux-android21"

%struct.MarshalMethodName = type {
	i64, ; uint64_t id
	ptr ; char* name
}

%struct.MarshalMethodsManagedClass = type {
	i32, ; uint32_t token
	ptr ; MonoClass klass
}

@assembly_image_cache = dso_local local_unnamed_addr global [328 x ptr] zeroinitializer, align 4

; Each entry maps hash of an assembly name to an index into the `assembly_image_cache` array
@assembly_image_cache_hashes = dso_local local_unnamed_addr constant [650 x i32] [
	i32 2616222, ; 0: System.Net.NetworkInformation.dll => 0x27eb9e => 68
	i32 5900400, ; 1: Apache.NMS.dll => 0x5a0870 => 173
	i32 10166715, ; 2: System.Net.NameResolution.dll => 0x9b21bb => 67
	i32 15721112, ; 3: System.Runtime.Intrinsics.dll => 0xefe298 => 108
	i32 32687329, ; 4: Xamarin.AndroidX.Lifecycle.Runtime => 0x1f2c4e1 => 248
	i32 34715100, ; 5: Xamarin.Google.Guava.ListenableFuture.dll => 0x211b5dc => 282
	i32 34839235, ; 6: System.IO.FileSystem.DriveInfo => 0x2139ac3 => 48
	i32 39109920, ; 7: Newtonsoft.Json.dll => 0x254c520 => 200
	i32 39485524, ; 8: System.Net.WebSockets.dll => 0x25a8054 => 80
	i32 42639949, ; 9: System.Threading.Thread => 0x28aa24d => 145
	i32 66541672, ; 10: System.Diagnostics.StackTrace => 0x3f75868 => 30
	i32 67008169, ; 11: zh-Hant\Microsoft.Maui.Controls.resources => 0x3fe76a9 => 323
	i32 68219467, ; 12: System.Security.Cryptography.Primitives => 0x410f24b => 124
	i32 72070932, ; 13: Microsoft.Maui.Graphics.dll => 0x44bb714 => 198
	i32 82292897, ; 14: System.Runtime.CompilerServices.VisualC.dll => 0x4e7b0a1 => 102
	i32 101534019, ; 15: Xamarin.AndroidX.SlidingPaneLayout => 0x60d4943 => 266
	i32 117431740, ; 16: System.Runtime.InteropServices => 0x6ffddbc => 107
	i32 120558881, ; 17: Xamarin.AndroidX.SlidingPaneLayout.dll => 0x72f9521 => 266
	i32 122350210, ; 18: System.Threading.Channels.dll => 0x74aea82 => 139
	i32 127363243, ; 19: ICSharpCode.SharpZipLib => 0x79768ab => 201
	i32 133096860, ; 20: Social network.dll => 0x7eee59c => 0
	i32 134690465, ; 21: Xamarin.Kotlin.StdLib.Jdk7.dll => 0x80736a1 => 286
	i32 142721839, ; 22: System.Net.WebHeaderCollection => 0x881c32f => 77
	i32 149972175, ; 23: System.Security.Cryptography.Primitives.dll => 0x8f064cf => 124
	i32 159306688, ; 24: System.ComponentModel.Annotations => 0x97ed3c0 => 13
	i32 165246403, ; 25: Xamarin.AndroidX.Collection.dll => 0x9d975c3 => 222
	i32 176265551, ; 26: System.ServiceProcess => 0xa81994f => 132
	i32 176331930, ; 27: StompNet.dll => 0xa829c9a => 203
	i32 182336117, ; 28: Xamarin.AndroidX.SwipeRefreshLayout.dll => 0xade3a75 => 268
	i32 184328833, ; 29: System.ValueTuple.dll => 0xafca281 => 151
	i32 195452805, ; 30: vi/Microsoft.Maui.Controls.resources.dll => 0xba65f85 => 320
	i32 199333315, ; 31: zh-HK/Microsoft.Maui.Controls.resources.dll => 0xbe195c3 => 321
	i32 205061960, ; 32: System.ComponentModel => 0xc38ff48 => 18
	i32 205943382, ; 33: WebSocket4Net => 0xc467256 => 206
	i32 209399409, ; 34: Xamarin.AndroidX.Browser.dll => 0xc7b2e71 => 220
	i32 220171995, ; 35: System.Diagnostics.Debug => 0xd1f8edb => 26
	i32 230216969, ; 36: Xamarin.AndroidX.Legacy.Support.Core.Utils.dll => 0xdb8d509 => 242
	i32 230752869, ; 37: Microsoft.CSharp.dll => 0xdc10265 => 1
	i32 231409092, ; 38: System.Linq.Parallel => 0xdcb05c4 => 59
	i32 231814094, ; 39: System.Globalization => 0xdd133ce => 42
	i32 246610117, ; 40: System.Reflection.Emit.Lightweight => 0xeb2f8c5 => 91
	i32 261689757, ; 41: Xamarin.AndroidX.ConstraintLayout.dll => 0xf99119d => 225
	i32 266174454, ; 42: IdentityModel.OidcClient.IdentityTokenValidator.dll => 0xfdd7ff6 => 179
	i32 276479776, ; 43: System.Threading.Timer.dll => 0x107abf20 => 147
	i32 278686392, ; 44: Xamarin.AndroidX.Lifecycle.LiveData.dll => 0x109c6ab8 => 244
	i32 280482487, ; 45: Xamarin.AndroidX.Interpolator => 0x10b7d2b7 => 241
	i32 280992041, ; 46: cs/Microsoft.Maui.Controls.resources.dll => 0x10bf9929 => 292
	i32 291076382, ; 47: System.IO.Pipes.AccessControl.dll => 0x1159791e => 54
	i32 298918909, ; 48: System.Net.Ping.dll => 0x11d123fd => 69
	i32 317674968, ; 49: vi\Microsoft.Maui.Controls.resources => 0x12ef55d8 => 320
	i32 318968648, ; 50: Xamarin.AndroidX.Activity.dll => 0x13031348 => 211
	i32 321597661, ; 51: System.Numerics => 0x132b30dd => 83
	i32 336156722, ; 52: ja/Microsoft.Maui.Controls.resources.dll => 0x14095832 => 305
	i32 342366114, ; 53: Xamarin.AndroidX.Lifecycle.Common => 0x146817a2 => 243
	i32 356389973, ; 54: it/Microsoft.Maui.Controls.resources.dll => 0x153e1455 => 304
	i32 360082299, ; 55: System.ServiceModel.Web => 0x15766b7b => 131
	i32 367780167, ; 56: System.IO.Pipes => 0x15ebe147 => 55
	i32 374914964, ; 57: System.Transactions.Local => 0x1658bf94 => 149
	i32 375677976, ; 58: System.Net.ServicePoint.dll => 0x16646418 => 74
	i32 379916513, ; 59: System.Threading.Thread.dll => 0x16a510e1 => 145
	i32 385762202, ; 60: System.Memory.dll => 0x16fe439a => 62
	i32 392610295, ; 61: System.Threading.ThreadPool.dll => 0x1766c1f7 => 146
	i32 395744057, ; 62: _Microsoft.Android.Resource.Designer => 0x17969339 => 324
	i32 403441872, ; 63: WindowsBase => 0x180c08d0 => 165
	i32 435591531, ; 64: sv/Microsoft.Maui.Controls.resources.dll => 0x19f6996b => 316
	i32 441335492, ; 65: Xamarin.AndroidX.ConstraintLayout.Core => 0x1a4e3ec4 => 226
	i32 442565967, ; 66: System.Collections => 0x1a61054f => 12
	i32 450948140, ; 67: Xamarin.AndroidX.Fragment.dll => 0x1ae0ec2c => 239
	i32 451504562, ; 68: System.Security.Cryptography.X509Certificates => 0x1ae969b2 => 125
	i32 456227837, ; 69: System.Web.HttpUtility.dll => 0x1b317bfd => 152
	i32 459347974, ; 70: System.Runtime.Serialization.Primitives.dll => 0x1b611806 => 113
	i32 465846621, ; 71: mscorlib => 0x1bc4415d => 166
	i32 469710990, ; 72: System.dll => 0x1bff388e => 164
	i32 476646585, ; 73: Xamarin.AndroidX.Interpolator.dll => 0x1c690cb9 => 241
	i32 485463106, ; 74: Microsoft.IdentityModel.Abstractions => 0x1cef9442 => 189
	i32 486930444, ; 75: Xamarin.AndroidX.LocalBroadcastManager.dll => 0x1d05f80c => 254
	i32 498788369, ; 76: System.ObjectModel => 0x1dbae811 => 84
	i32 500358224, ; 77: id/Microsoft.Maui.Controls.resources.dll => 0x1dd2dc50 => 303
	i32 503918385, ; 78: fi/Microsoft.Maui.Controls.resources.dll => 0x1e092f31 => 297
	i32 512678996, ; 79: Extend => 0x1e8edc54 => 175
	i32 513247710, ; 80: Microsoft.Extensions.Primitives.dll => 0x1e9789de => 188
	i32 526420162, ; 81: System.Transactions.dll => 0x1f6088c2 => 150
	i32 527452488, ; 82: Xamarin.Kotlin.StdLib.Jdk7 => 0x1f704948 => 286
	i32 530272170, ; 83: System.Linq.Queryable => 0x1f9b4faa => 60
	i32 539058512, ; 84: Microsoft.Extensions.Logging => 0x20216150 => 184
	i32 540030774, ; 85: System.IO.FileSystem.dll => 0x20303736 => 51
	i32 545304856, ; 86: System.Runtime.Extensions => 0x2080b118 => 103
	i32 546455878, ; 87: System.Runtime.Serialization.Xml => 0x20924146 => 114
	i32 549171840, ; 88: System.Globalization.Calendars => 0x20bbb280 => 40
	i32 551341617, ; 89: Stomp.Net.dll => 0x20dcce31 => 202
	i32 557405415, ; 90: Jsr305Binding => 0x213954e7 => 279
	i32 569601784, ; 91: Xamarin.AndroidX.Window.Extensions.Core.Core => 0x21f36ef8 => 277
	i32 577335427, ; 92: System.Security.Cryptography.Cng => 0x22697083 => 120
	i32 592146354, ; 93: pt-BR/Microsoft.Maui.Controls.resources.dll => 0x234b6fb2 => 311
	i32 601371474, ; 94: System.IO.IsolatedStorage.dll => 0x23d83352 => 52
	i32 605376203, ; 95: System.IO.Compression.FileSystem => 0x24154ecb => 44
	i32 613668793, ; 96: System.Security.Cryptography.Algorithms => 0x2493d7b9 => 119
	i32 627609679, ; 97: Xamarin.AndroidX.CustomView => 0x2568904f => 231
	i32 627931235, ; 98: nl\Microsoft.Maui.Controls.resources => 0x256d7863 => 309
	i32 639843206, ; 99: Xamarin.AndroidX.Emoji2.ViewsHelper.dll => 0x26233b86 => 237
	i32 643868501, ; 100: System.Net => 0x2660a755 => 81
	i32 662205335, ; 101: System.Text.Encodings.Web.dll => 0x27787397 => 136
	i32 663517072, ; 102: Xamarin.AndroidX.VersionedParcelable => 0x278c7790 => 273
	i32 666292255, ; 103: Xamarin.AndroidX.Arch.Core.Common.dll => 0x27b6d01f => 218
	i32 672442732, ; 104: System.Collections.Concurrent => 0x2814a96c => 8
	i32 683518922, ; 105: System.Net.Security => 0x28bdabca => 73
	i32 688181140, ; 106: ca/Microsoft.Maui.Controls.resources.dll => 0x2904cf94 => 291
	i32 690569205, ; 107: System.Xml.Linq.dll => 0x29293ff5 => 155
	i32 691348768, ; 108: Xamarin.KotlinX.Coroutines.Android.dll => 0x29352520 => 288
	i32 693804605, ; 109: System.Windows => 0x295a9e3d => 154
	i32 699345723, ; 110: System.Reflection.Emit => 0x29af2b3b => 92
	i32 700284507, ; 111: Xamarin.Jetbrains.Annotations => 0x29bd7e5b => 283
	i32 700358131, ; 112: System.IO.Compression.ZipFile => 0x29be9df3 => 45
	i32 706645707, ; 113: ko/Microsoft.Maui.Controls.resources.dll => 0x2a1e8ecb => 306
	i32 709557578, ; 114: de/Microsoft.Maui.Controls.resources.dll => 0x2a4afd4a => 294
	i32 720511267, ; 115: Xamarin.Kotlin.StdLib.Jdk8 => 0x2af22123 => 287
	i32 722857257, ; 116: System.Runtime.Loader.dll => 0x2b15ed29 => 109
	i32 735137430, ; 117: System.Security.SecureString.dll => 0x2bd14e96 => 129
	i32 752232764, ; 118: System.Diagnostics.Contracts.dll => 0x2cd6293c => 25
	i32 755313932, ; 119: Xamarin.Android.Glide.Annotations.dll => 0x2d052d0c => 208
	i32 759454413, ; 120: System.Net.Requests => 0x2d445acd => 72
	i32 762598435, ; 121: System.IO.Pipes.dll => 0x2d745423 => 55
	i32 775507847, ; 122: System.IO.Compression => 0x2e394f87 => 46
	i32 777317022, ; 123: sk\Microsoft.Maui.Controls.resources => 0x2e54ea9e => 315
	i32 789151979, ; 124: Microsoft.Extensions.Options => 0x2f0980eb => 187
	i32 790371945, ; 125: Xamarin.AndroidX.CustomView.PoolingContainer.dll => 0x2f1c1e69 => 232
	i32 804715423, ; 126: System.Data.Common => 0x2ff6fb9f => 22
	i32 807930345, ; 127: Xamarin.AndroidX.Lifecycle.LiveData.Core.Ktx.dll => 0x302809e9 => 246
	i32 823281589, ; 128: System.Private.Uri.dll => 0x311247b5 => 86
	i32 830298997, ; 129: System.IO.Compression.Brotli => 0x317d5b75 => 43
	i32 832635846, ; 130: System.Xml.XPath.dll => 0x31a103c6 => 160
	i32 834051424, ; 131: System.Net.Quic => 0x31b69d60 => 71
	i32 843511501, ; 132: Xamarin.AndroidX.Print => 0x3246f6cd => 259
	i32 873119928, ; 133: Microsoft.VisualBasic => 0x340ac0b8 => 3
	i32 877678880, ; 134: System.Globalization.dll => 0x34505120 => 42
	i32 878954865, ; 135: System.Net.Http.Json => 0x3463c971 => 63
	i32 888076676, ; 136: IdentityModel.OidcClient.dll => 0x34eef984 => 178
	i32 904024072, ; 137: System.ComponentModel.Primitives.dll => 0x35e25008 => 16
	i32 911108515, ; 138: System.IO.MemoryMappedFiles.dll => 0x364e69a3 => 53
	i32 926902833, ; 139: tr/Microsoft.Maui.Controls.resources.dll => 0x373f6a31 => 318
	i32 928116545, ; 140: Xamarin.Google.Guava.ListenableFuture => 0x3751ef41 => 282
	i32 952186615, ; 141: System.Runtime.InteropServices.JavaScript.dll => 0x38c136f7 => 105
	i32 955402788, ; 142: Newtonsoft.Json => 0x38f24a24 => 200
	i32 956575887, ; 143: Xamarin.Kotlin.StdLib.Jdk8.dll => 0x3904308f => 287
	i32 966729478, ; 144: Xamarin.Google.Crypto.Tink.Android => 0x399f1f06 => 280
	i32 967690846, ; 145: Xamarin.AndroidX.Lifecycle.Common.dll => 0x39adca5e => 243
	i32 975236339, ; 146: System.Diagnostics.Tracing => 0x3a20ecf3 => 34
	i32 975874589, ; 147: System.Xml.XDocument => 0x3a2aaa1d => 158
	i32 986514023, ; 148: System.Private.DataContractSerialization.dll => 0x3acd0267 => 85
	i32 987214855, ; 149: System.Diagnostics.Tools => 0x3ad7b407 => 32
	i32 992768348, ; 150: System.Collections.dll => 0x3b2c715c => 12
	i32 994442037, ; 151: System.IO.FileSystem => 0x3b45fb35 => 51
	i32 1001831731, ; 152: System.IO.UnmanagedMemoryStream.dll => 0x3bb6bd33 => 56
	i32 1012816738, ; 153: Xamarin.AndroidX.SavedState.dll => 0x3c5e5b62 => 263
	i32 1019214401, ; 154: System.Drawing => 0x3cbffa41 => 36
	i32 1028951442, ; 155: Microsoft.Extensions.DependencyInjection.Abstractions => 0x3d548d92 => 183
	i32 1029334545, ; 156: da/Microsoft.Maui.Controls.resources.dll => 0x3d5a6611 => 293
	i32 1031528504, ; 157: Xamarin.Google.ErrorProne.Annotations.dll => 0x3d7be038 => 281
	i32 1035644815, ; 158: Xamarin.AndroidX.AppCompat => 0x3dbaaf8f => 216
	i32 1036536393, ; 159: System.Drawing.Primitives.dll => 0x3dc84a49 => 35
	i32 1044663988, ; 160: System.Linq.Expressions.dll => 0x3e444eb4 => 58
	i32 1052210849, ; 161: Xamarin.AndroidX.Lifecycle.ViewModel.dll => 0x3eb776a1 => 250
	i32 1067306892, ; 162: GoogleGson => 0x3f9dcf8c => 176
	i32 1082857460, ; 163: System.ComponentModel.TypeConverter => 0x408b17f4 => 17
	i32 1084122840, ; 164: Xamarin.Kotlin.StdLib => 0x409e66d8 => 284
	i32 1098259244, ; 165: System => 0x41761b2c => 164
	i32 1118262833, ; 166: ko\Microsoft.Maui.Controls.resources => 0x42a75631 => 306
	i32 1121599056, ; 167: Xamarin.AndroidX.Lifecycle.Runtime.Ktx.dll => 0x42da3e50 => 249
	i32 1127624469, ; 168: Microsoft.Extensions.Logging.Debug => 0x43362f15 => 186
	i32 1149092582, ; 169: Xamarin.AndroidX.Window => 0x447dc2e6 => 276
	i32 1168523401, ; 170: pt\Microsoft.Maui.Controls.resources => 0x45a64089 => 312
	i32 1170634674, ; 171: System.Web.dll => 0x45c677b2 => 153
	i32 1175144683, ; 172: Xamarin.AndroidX.VectorDrawable.Animated => 0x460b48eb => 272
	i32 1178241025, ; 173: Xamarin.AndroidX.Navigation.Runtime.dll => 0x463a8801 => 257
	i32 1203215381, ; 174: pl/Microsoft.Maui.Controls.resources.dll => 0x47b79c15 => 310
	i32 1204270330, ; 175: Xamarin.AndroidX.Arch.Core.Common => 0x47c7b4fa => 218
	i32 1208641965, ; 176: System.Diagnostics.Process => 0x480a69ad => 29
	i32 1219128291, ; 177: System.IO.IsolatedStorage => 0x48aa6be3 => 52
	i32 1234928153, ; 178: nb/Microsoft.Maui.Controls.resources.dll => 0x499b8219 => 308
	i32 1243150071, ; 179: Xamarin.AndroidX.Window.Extensions.Core.Core.dll => 0x4a18f6f7 => 277
	i32 1253011324, ; 180: Microsoft.Win32.Registry => 0x4aaf6f7c => 5
	i32 1260983243, ; 181: cs\Microsoft.Maui.Controls.resources => 0x4b2913cb => 292
	i32 1264511973, ; 182: Xamarin.AndroidX.Startup.StartupRuntime.dll => 0x4b5eebe5 => 267
	i32 1267360935, ; 183: Xamarin.AndroidX.VectorDrawable => 0x4b8a64a7 => 271
	i32 1273260888, ; 184: Xamarin.AndroidX.Collection.Ktx => 0x4be46b58 => 223
	i32 1275534314, ; 185: Xamarin.KotlinX.Coroutines.Android => 0x4c071bea => 288
	i32 1278448581, ; 186: Xamarin.AndroidX.Annotation.Jvm => 0x4c3393c5 => 215
	i32 1293217323, ; 187: Xamarin.AndroidX.DrawerLayout.dll => 0x4d14ee2b => 234
	i32 1309188875, ; 188: System.Private.DataContractSerialization => 0x4e08a30b => 85
	i32 1310647349, ; 189: WebSocket4Net.dll => 0x4e1ee435 => 206
	i32 1322716291, ; 190: Xamarin.AndroidX.Window.dll => 0x4ed70c83 => 276
	i32 1324164729, ; 191: System.Linq => 0x4eed2679 => 61
	i32 1335329327, ; 192: System.Runtime.Serialization.Json.dll => 0x4f97822f => 112
	i32 1364015309, ; 193: System.IO => 0x514d38cd => 57
	i32 1373134921, ; 194: zh-Hans\Microsoft.Maui.Controls.resources => 0x51d86049 => 322
	i32 1376866003, ; 195: Xamarin.AndroidX.SavedState => 0x52114ed3 => 263
	i32 1379779777, ; 196: System.Resources.ResourceManager => 0x523dc4c1 => 99
	i32 1402170036, ; 197: System.Configuration.dll => 0x53936ab4 => 19
	i32 1406073936, ; 198: Xamarin.AndroidX.CoordinatorLayout => 0x53cefc50 => 227
	i32 1408764838, ; 199: System.Runtime.Serialization.Formatters.dll => 0x53f80ba6 => 111
	i32 1411638395, ; 200: System.Runtime.CompilerServices.Unsafe => 0x5423e47b => 101
	i32 1422545099, ; 201: System.Runtime.CompilerServices.VisualC => 0x54ca50cb => 102
	i32 1430672901, ; 202: ar\Microsoft.Maui.Controls.resources => 0x55465605 => 290
	i32 1434145427, ; 203: System.Runtime.Handles => 0x557b5293 => 104
	i32 1435222561, ; 204: Xamarin.Google.Crypto.Tink.Android.dll => 0x558bc221 => 280
	i32 1439761251, ; 205: System.Net.Quic.dll => 0x55d10363 => 71
	i32 1452070440, ; 206: System.Formats.Asn1.dll => 0x568cd628 => 38
	i32 1453312822, ; 207: System.Diagnostics.Tools.dll => 0x569fcb36 => 32
	i32 1457743152, ; 208: System.Runtime.Extensions.dll => 0x56e36530 => 103
	i32 1458022317, ; 209: System.Net.Security.dll => 0x56e7a7ad => 73
	i32 1460893475, ; 210: System.IdentityModel.Tokens.Jwt => 0x57137723 => 205
	i32 1461004990, ; 211: es\Microsoft.Maui.Controls.resources => 0x57152abe => 296
	i32 1461234159, ; 212: System.Collections.Immutable.dll => 0x5718a9ef => 9
	i32 1461719063, ; 213: System.Security.Cryptography.OpenSsl => 0x57201017 => 123
	i32 1462112819, ; 214: System.IO.Compression.dll => 0x57261233 => 46
	i32 1469204771, ; 215: Xamarin.AndroidX.AppCompat.AppCompatResources => 0x57924923 => 217
	i32 1470490898, ; 216: Microsoft.Extensions.Primitives => 0x57a5e912 => 188
	i32 1479771757, ; 217: System.Collections.Immutable => 0x5833866d => 9
	i32 1480492111, ; 218: System.IO.Compression.Brotli.dll => 0x583e844f => 43
	i32 1487239319, ; 219: Microsoft.Win32.Primitives => 0x58a57897 => 4
	i32 1490025113, ; 220: Xamarin.AndroidX.SavedState.SavedState.Ktx.dll => 0x58cffa99 => 264
	i32 1493001747, ; 221: hi/Microsoft.Maui.Controls.resources.dll => 0x58fd6613 => 300
	i32 1498168481, ; 222: Microsoft.IdentityModel.JsonWebTokens.dll => 0x594c3ca1 => 190
	i32 1514721132, ; 223: el/Microsoft.Maui.Controls.resources.dll => 0x5a48cf6c => 295
	i32 1536373174, ; 224: System.Diagnostics.TextWriterTraceListener => 0x5b9331b6 => 31
	i32 1543031311, ; 225: System.Text.RegularExpressions.dll => 0x5bf8ca0f => 138
	i32 1543355203, ; 226: System.Reflection.Emit.dll => 0x5bfdbb43 => 92
	i32 1550322496, ; 227: System.Reflection.Extensions.dll => 0x5c680b40 => 93
	i32 1551623176, ; 228: sk/Microsoft.Maui.Controls.resources.dll => 0x5c7be408 => 315
	i32 1565862583, ; 229: System.IO.FileSystem.Primitives => 0x5d552ab7 => 49
	i32 1566207040, ; 230: System.Threading.Tasks.Dataflow.dll => 0x5d5a6c40 => 141
	i32 1573704789, ; 231: System.Runtime.Serialization.Json => 0x5dccd455 => 112
	i32 1580037396, ; 232: System.Threading.Overlapped => 0x5e2d7514 => 140
	i32 1582372066, ; 233: Xamarin.AndroidX.DocumentFile.dll => 0x5e5114e2 => 233
	i32 1592978981, ; 234: System.Runtime.Serialization.dll => 0x5ef2ee25 => 115
	i32 1597949149, ; 235: Xamarin.Google.ErrorProne.Annotations => 0x5f3ec4dd => 281
	i32 1601112923, ; 236: System.Xml.Serialization => 0x5f6f0b5b => 157
	i32 1604827217, ; 237: System.Net.WebClient => 0x5fa7b851 => 76
	i32 1618516317, ; 238: System.Net.WebSockets.Client.dll => 0x6078995d => 79
	i32 1622152042, ; 239: Xamarin.AndroidX.Loader.dll => 0x60b0136a => 253
	i32 1622358360, ; 240: System.Dynamic.Runtime => 0x60b33958 => 37
	i32 1624863272, ; 241: Xamarin.AndroidX.ViewPager2 => 0x60d97228 => 275
	i32 1635184631, ; 242: Xamarin.AndroidX.Emoji2.ViewsHelper => 0x6176eff7 => 237
	i32 1636350590, ; 243: Xamarin.AndroidX.CursorAdapter => 0x6188ba7e => 230
	i32 1639515021, ; 244: System.Net.Http.dll => 0x61b9038d => 64
	i32 1639986890, ; 245: System.Text.RegularExpressions => 0x61c036ca => 138
	i32 1641389582, ; 246: System.ComponentModel.EventBasedAsync.dll => 0x61d59e0e => 15
	i32 1657153582, ; 247: System.Runtime => 0x62c6282e => 116
	i32 1658241508, ; 248: Xamarin.AndroidX.Tracing.Tracing.dll => 0x62d6c1e4 => 269
	i32 1658251792, ; 249: Xamarin.Google.Android.Material.dll => 0x62d6ea10 => 278
	i32 1670060433, ; 250: Xamarin.AndroidX.ConstraintLayout => 0x638b1991 => 225
	i32 1675553242, ; 251: System.IO.FileSystem.DriveInfo.dll => 0x63dee9da => 48
	i32 1677501392, ; 252: System.Net.Primitives.dll => 0x63fca3d0 => 70
	i32 1678508291, ; 253: System.Net.WebSockets => 0x640c0103 => 80
	i32 1679769178, ; 254: System.Security.Cryptography => 0x641f3e5a => 126
	i32 1691477237, ; 255: System.Reflection.Metadata => 0x64d1e4f5 => 94
	i32 1696967625, ; 256: System.Security.Cryptography.Csp => 0x6525abc9 => 121
	i32 1698840827, ; 257: Xamarin.Kotlin.StdLib.Common => 0x654240fb => 285
	i32 1701541528, ; 258: System.Diagnostics.Debug.dll => 0x656b7698 => 26
	i32 1720223769, ; 259: Xamarin.AndroidX.Lifecycle.LiveData.Core.Ktx => 0x66888819 => 246
	i32 1726116996, ; 260: System.Reflection.dll => 0x66e27484 => 97
	i32 1728033016, ; 261: System.Diagnostics.FileVersionInfo.dll => 0x66ffb0f8 => 28
	i32 1729485958, ; 262: Xamarin.AndroidX.CardView.dll => 0x6715dc86 => 221
	i32 1736233607, ; 263: ro/Microsoft.Maui.Controls.resources.dll => 0x677cd287 => 313
	i32 1743415430, ; 264: ca\Microsoft.Maui.Controls.resources => 0x67ea6886 => 291
	i32 1744735666, ; 265: System.Transactions.Local.dll => 0x67fe8db2 => 149
	i32 1746316138, ; 266: Mono.Android.Export => 0x6816ab6a => 169
	i32 1750313021, ; 267: Microsoft.Win32.Primitives.dll => 0x6853a83d => 4
	i32 1758240030, ; 268: System.Resources.Reader.dll => 0x68cc9d1e => 98
	i32 1763938596, ; 269: System.Diagnostics.TraceSource.dll => 0x69239124 => 33
	i32 1765942094, ; 270: System.Reflection.Extensions => 0x6942234e => 93
	i32 1766324549, ; 271: Xamarin.AndroidX.SwipeRefreshLayout => 0x6947f945 => 268
	i32 1770582343, ; 272: Microsoft.Extensions.Logging.dll => 0x6988f147 => 184
	i32 1776026572, ; 273: System.Core.dll => 0x69dc03cc => 21
	i32 1777075843, ; 274: System.Globalization.Extensions.dll => 0x69ec0683 => 41
	i32 1780572499, ; 275: Mono.Android.Runtime.dll => 0x6a216153 => 170
	i32 1782862114, ; 276: ms\Microsoft.Maui.Controls.resources => 0x6a445122 => 307
	i32 1788241197, ; 277: Xamarin.AndroidX.Fragment => 0x6a96652d => 239
	i32 1793755602, ; 278: he\Microsoft.Maui.Controls.resources => 0x6aea89d2 => 299
	i32 1808609942, ; 279: Xamarin.AndroidX.Loader => 0x6bcd3296 => 253
	i32 1813058853, ; 280: Xamarin.Kotlin.StdLib.dll => 0x6c111525 => 284
	i32 1813201214, ; 281: Xamarin.Google.Android.Material => 0x6c13413e => 278
	i32 1818569960, ; 282: Xamarin.AndroidX.Navigation.UI.dll => 0x6c652ce8 => 258
	i32 1818787751, ; 283: Microsoft.VisualBasic.Core => 0x6c687fa7 => 2
	i32 1824175904, ; 284: System.Text.Encoding.Extensions => 0x6cbab720 => 134
	i32 1824722060, ; 285: System.Runtime.Serialization.Formatters => 0x6cc30c8c => 111
	i32 1828688058, ; 286: Microsoft.Extensions.Logging.Abstractions.dll => 0x6cff90ba => 185
	i32 1842015223, ; 287: uk/Microsoft.Maui.Controls.resources.dll => 0x6dcaebf7 => 319
	i32 1847515442, ; 288: Xamarin.Android.Glide.Annotations => 0x6e1ed932 => 208
	i32 1853025655, ; 289: sv\Microsoft.Maui.Controls.resources => 0x6e72ed77 => 316
	i32 1858542181, ; 290: System.Linq.Expressions => 0x6ec71a65 => 58
	i32 1870277092, ; 291: System.Reflection.Primitives => 0x6f7a29e4 => 95
	i32 1875480394, ; 292: IdentityModel => 0x6fc98f4a => 177
	i32 1875935024, ; 293: fr\Microsoft.Maui.Controls.resources => 0x6fd07f30 => 298
	i32 1879696579, ; 294: System.Formats.Tar.dll => 0x7009e4c3 => 39
	i32 1885316902, ; 295: Xamarin.AndroidX.Arch.Core.Runtime.dll => 0x705fa726 => 219
	i32 1888955245, ; 296: System.Diagnostics.Contracts => 0x70972b6d => 25
	i32 1889954781, ; 297: System.Reflection.Metadata.dll => 0x70a66bdd => 94
	i32 1898237753, ; 298: System.Reflection.DispatchProxy => 0x7124cf39 => 89
	i32 1900610850, ; 299: System.Resources.ResourceManager.dll => 0x71490522 => 99
	i32 1910275211, ; 300: System.Collections.NonGeneric.dll => 0x71dc7c8b => 10
	i32 1939592360, ; 301: System.Private.Xml.Linq => 0x739bd4a8 => 87
	i32 1956758971, ; 302: System.Resources.Writer => 0x74a1c5bb => 100
	i32 1961813231, ; 303: Xamarin.AndroidX.Security.SecurityCrypto.dll => 0x74eee4ef => 265
	i32 1968388702, ; 304: Microsoft.Extensions.Configuration.dll => 0x75533a5e => 180
	i32 1983156543, ; 305: Xamarin.Kotlin.StdLib.Common.dll => 0x7634913f => 285
	i32 1985761444, ; 306: Xamarin.Android.Glide.GifDecoder => 0x765c50a4 => 210
	i32 1986222447, ; 307: Microsoft.IdentityModel.Tokens.dll => 0x7663596f => 192
	i32 2003115576, ; 308: el\Microsoft.Maui.Controls.resources => 0x77651e38 => 295
	i32 2011961780, ; 309: System.Buffers.dll => 0x77ec19b4 => 7
	i32 2019465201, ; 310: Xamarin.AndroidX.Lifecycle.ViewModel => 0x785e97f1 => 250
	i32 2025202353, ; 311: ar/Microsoft.Maui.Controls.resources.dll => 0x78b622b1 => 290
	i32 2031763787, ; 312: Xamarin.Android.Glide => 0x791a414b => 207
	i32 2045470958, ; 313: System.Private.Xml => 0x79eb68ee => 88
	i32 2055257422, ; 314: Xamarin.AndroidX.Lifecycle.LiveData.Core.dll => 0x7a80bd4e => 245
	i32 2060060697, ; 315: System.Windows.dll => 0x7aca0819 => 154
	i32 2066184531, ; 316: de\Microsoft.Maui.Controls.resources => 0x7b277953 => 294
	i32 2070888862, ; 317: System.Diagnostics.TraceSource => 0x7b6f419e => 33
	i32 2079903147, ; 318: System.Runtime.dll => 0x7bf8cdab => 116
	i32 2090596640, ; 319: System.Numerics.Vectors => 0x7c9bf920 => 82
	i32 2127167465, ; 320: System.Console => 0x7ec9ffe9 => 20
	i32 2142473426, ; 321: System.Collections.Specialized => 0x7fb38cd2 => 11
	i32 2143790110, ; 322: System.Xml.XmlSerializer.dll => 0x7fc7a41e => 162
	i32 2146852085, ; 323: Microsoft.VisualBasic.dll => 0x7ff65cf5 => 3
	i32 2159891885, ; 324: Microsoft.Maui => 0x80bd55ad => 196
	i32 2169148018, ; 325: hu\Microsoft.Maui.Controls.resources => 0x814a9272 => 302
	i32 2181898931, ; 326: Microsoft.Extensions.Options.dll => 0x820d22b3 => 187
	i32 2192057212, ; 327: Microsoft.Extensions.Logging.Abstractions => 0x82a8237c => 185
	i32 2193016926, ; 328: System.ObjectModel.dll => 0x82b6c85e => 84
	i32 2201107256, ; 329: Xamarin.KotlinX.Coroutines.Core.Jvm.dll => 0x83323b38 => 289
	i32 2201231467, ; 330: System.Net.Http => 0x8334206b => 64
	i32 2207618523, ; 331: it\Microsoft.Maui.Controls.resources => 0x839595db => 304
	i32 2217644978, ; 332: Xamarin.AndroidX.VectorDrawable.Animated.dll => 0x842e93b2 => 272
	i32 2222056684, ; 333: System.Threading.Tasks.Parallel => 0x8471e4ec => 143
	i32 2244775296, ; 334: Xamarin.AndroidX.LocalBroadcastManager => 0x85cc8d80 => 254
	i32 2252106437, ; 335: System.Xml.Serialization.dll => 0x863c6ac5 => 157
	i32 2256313426, ; 336: System.Globalization.Extensions => 0x867c9c52 => 41
	i32 2265110946, ; 337: System.Security.AccessControl.dll => 0x8702d9a2 => 117
	i32 2266799131, ; 338: Microsoft.Extensions.Configuration.Abstractions => 0x871c9c1b => 181
	i32 2267999099, ; 339: Xamarin.Android.Glide.DiskLruCache.dll => 0x872eeb7b => 209
	i32 2270573516, ; 340: fr/Microsoft.Maui.Controls.resources.dll => 0x875633cc => 298
	i32 2279755925, ; 341: Xamarin.AndroidX.RecyclerView.dll => 0x87e25095 => 261
	i32 2293034957, ; 342: System.ServiceModel.Web.dll => 0x88acefcd => 131
	i32 2295906218, ; 343: System.Net.Sockets => 0x88d8bfaa => 75
	i32 2298471582, ; 344: System.Net.Mail => 0x88ffe49e => 66
	i32 2303942373, ; 345: nb\Microsoft.Maui.Controls.resources => 0x89535ee5 => 308
	i32 2305521784, ; 346: System.Private.CoreLib.dll => 0x896b7878 => 172
	i32 2315684594, ; 347: Xamarin.AndroidX.Annotation.dll => 0x8a068af2 => 213
	i32 2320631194, ; 348: System.Threading.Tasks.Parallel.dll => 0x8a52059a => 143
	i32 2329778642, ; 349: Apache.NMS => 0x8add99d2 => 173
	i32 2340441535, ; 350: System.Runtime.InteropServices.RuntimeInformation.dll => 0x8b804dbf => 106
	i32 2344264397, ; 351: System.ValueTuple => 0x8bbaa2cd => 151
	i32 2353062107, ; 352: System.Net.Primitives => 0x8c40e0db => 70
	i32 2368005991, ; 353: System.Xml.ReaderWriter.dll => 0x8d24e767 => 156
	i32 2369706906, ; 354: Microsoft.IdentityModel.Logging => 0x8d3edb9a => 191
	i32 2371007202, ; 355: Microsoft.Extensions.Configuration => 0x8d52b2e2 => 180
	i32 2378619854, ; 356: System.Security.Cryptography.Csp.dll => 0x8dc6dbce => 121
	i32 2383496789, ; 357: System.Security.Principal.Windows.dll => 0x8e114655 => 127
	i32 2395872292, ; 358: id\Microsoft.Maui.Controls.resources => 0x8ece1c24 => 303
	i32 2401565422, ; 359: System.Web.HttpUtility => 0x8f24faee => 152
	i32 2403452196, ; 360: Xamarin.AndroidX.Emoji2.dll => 0x8f41c524 => 236
	i32 2421380589, ; 361: System.Threading.Tasks.Dataflow => 0x905355ed => 141
	i32 2423080555, ; 362: Xamarin.AndroidX.Collection.Ktx.dll => 0x906d466b => 223
	i32 2427813419, ; 363: hi\Microsoft.Maui.Controls.resources => 0x90b57e2b => 300
	i32 2435356389, ; 364: System.Console.dll => 0x912896e5 => 20
	i32 2435904999, ; 365: System.ComponentModel.DataAnnotations.dll => 0x9130f5e7 => 14
	i32 2454642406, ; 366: System.Text.Encoding.dll => 0x924edee6 => 135
	i32 2458678730, ; 367: System.Net.Sockets.dll => 0x928c75ca => 75
	i32 2459001652, ; 368: System.Linq.Parallel.dll => 0x92916334 => 59
	i32 2465532216, ; 369: Xamarin.AndroidX.ConstraintLayout.Core.dll => 0x92f50938 => 226
	i32 2471841756, ; 370: netstandard.dll => 0x93554fdc => 167
	i32 2475788418, ; 371: Java.Interop.dll => 0x93918882 => 168
	i32 2480646305, ; 372: Microsoft.Maui.Controls => 0x93dba8a1 => 194
	i32 2483903535, ; 373: System.ComponentModel.EventBasedAsync => 0x940d5c2f => 15
	i32 2484371297, ; 374: System.Net.ServicePoint => 0x94147f61 => 74
	i32 2490993605, ; 375: System.AppContext.dll => 0x94798bc5 => 6
	i32 2497152587, ; 376: Microsoft.Toolkit.Mvvm => 0x94d7864b => 199
	i32 2501346920, ; 377: System.Data.DataSetExtensions => 0x95178668 => 23
	i32 2505896520, ; 378: Xamarin.AndroidX.Lifecycle.Runtime.dll => 0x955cf248 => 248
	i32 2522472828, ; 379: Xamarin.Android.Glide.dll => 0x9659e17c => 207
	i32 2538310050, ; 380: System.Reflection.Emit.Lightweight.dll => 0x974b89a2 => 91
	i32 2550873716, ; 381: hr\Microsoft.Maui.Controls.resources => 0x980b3e74 => 301
	i32 2562349572, ; 382: Microsoft.CSharp => 0x98ba5a04 => 1
	i32 2570120770, ; 383: System.Text.Encodings.Web => 0x9930ee42 => 136
	i32 2581783588, ; 384: Xamarin.AndroidX.Lifecycle.Runtime.Ktx => 0x99e2e424 => 249
	i32 2581819634, ; 385: Xamarin.AndroidX.VectorDrawable.dll => 0x99e370f2 => 271
	i32 2585220780, ; 386: System.Text.Encoding.Extensions.dll => 0x9a1756ac => 134
	i32 2585805581, ; 387: System.Net.Ping => 0x9a20430d => 69
	i32 2589602615, ; 388: System.Threading.ThreadPool => 0x9a5a3337 => 146
	i32 2593496499, ; 389: pl\Microsoft.Maui.Controls.resources => 0x9a959db3 => 310
	i32 2605712449, ; 390: Xamarin.KotlinX.Coroutines.Core.Jvm => 0x9b500441 => 289
	i32 2615233544, ; 391: Xamarin.AndroidX.Fragment.Ktx => 0x9be14c08 => 240
	i32 2616218305, ; 392: Microsoft.Extensions.Logging.Debug.dll => 0x9bf052c1 => 186
	i32 2617129537, ; 393: System.Private.Xml.dll => 0x9bfe3a41 => 88
	i32 2618712057, ; 394: System.Reflection.TypeExtensions.dll => 0x9c165ff9 => 96
	i32 2620871830, ; 395: Xamarin.AndroidX.CursorAdapter.dll => 0x9c375496 => 230
	i32 2624644809, ; 396: Xamarin.AndroidX.DynamicAnimation => 0x9c70e6c9 => 235
	i32 2626831493, ; 397: ja\Microsoft.Maui.Controls.resources => 0x9c924485 => 305
	i32 2627185994, ; 398: System.Diagnostics.TextWriterTraceListener.dll => 0x9c97ad4a => 31
	i32 2629843544, ; 399: System.IO.Compression.ZipFile.dll => 0x9cc03a58 => 45
	i32 2633051222, ; 400: Xamarin.AndroidX.Lifecycle.LiveData => 0x9cf12c56 => 244
	i32 2640290731, ; 401: Microsoft.IdentityModel.Logging.dll => 0x9d5fa3ab => 191
	i32 2663391936, ; 402: Xamarin.Android.Glide.DiskLruCache => 0x9ec022c0 => 209
	i32 2663698177, ; 403: System.Runtime.Loader => 0x9ec4cf01 => 109
	i32 2664396074, ; 404: System.Xml.XDocument.dll => 0x9ecf752a => 158
	i32 2665622720, ; 405: System.Drawing.Primitives => 0x9ee22cc0 => 35
	i32 2676780864, ; 406: System.Data.Common.dll => 0x9f8c6f40 => 22
	i32 2686887180, ; 407: System.Runtime.Serialization.Xml.dll => 0xa026a50c => 114
	i32 2693849962, ; 408: System.IO.dll => 0xa090e36a => 57
	i32 2701096212, ; 409: Xamarin.AndroidX.Tracing.Tracing => 0xa0ff7514 => 269
	i32 2715334215, ; 410: System.Threading.Tasks.dll => 0xa1d8b647 => 144
	i32 2717744543, ; 411: System.Security.Claims => 0xa1fd7d9f => 118
	i32 2719963679, ; 412: System.Security.Cryptography.Cng.dll => 0xa21f5a1f => 120
	i32 2724373263, ; 413: System.Runtime.Numerics.dll => 0xa262a30f => 110
	i32 2732626843, ; 414: Xamarin.AndroidX.Activity => 0xa2e0939b => 211
	i32 2735172069, ; 415: System.Threading.Channels => 0xa30769e5 => 139
	i32 2737747696, ; 416: Xamarin.AndroidX.AppCompat.AppCompatResources.dll => 0xa32eb6f0 => 217
	i32 2740948882, ; 417: System.IO.Pipes.AccessControl => 0xa35f8f92 => 54
	i32 2748088231, ; 418: System.Runtime.InteropServices.JavaScript => 0xa3cc7fa7 => 105
	i32 2752995522, ; 419: pt-BR\Microsoft.Maui.Controls.resources => 0xa41760c2 => 311
	i32 2758225723, ; 420: Microsoft.Maui.Controls.Xaml => 0xa4672f3b => 195
	i32 2764765095, ; 421: Microsoft.Maui.dll => 0xa4caf7a7 => 196
	i32 2765824710, ; 422: System.Text.Encoding.CodePages.dll => 0xa4db22c6 => 133
	i32 2770495804, ; 423: Xamarin.Jetbrains.Annotations.dll => 0xa522693c => 283
	i32 2778768386, ; 424: Xamarin.AndroidX.ViewPager.dll => 0xa5a0a402 => 274
	i32 2779977773, ; 425: Xamarin.AndroidX.ResourceInspection.Annotation.dll => 0xa5b3182d => 262
	i32 2785988530, ; 426: th\Microsoft.Maui.Controls.resources => 0xa60ecfb2 => 317
	i32 2788224221, ; 427: Xamarin.AndroidX.Fragment.Ktx.dll => 0xa630ecdd => 240
	i32 2792585614, ; 428: Extend.dll => 0xa673798e => 175
	i32 2801831435, ; 429: Microsoft.Maui.Graphics => 0xa7008e0b => 198
	i32 2803228030, ; 430: System.Xml.XPath.XDocument.dll => 0xa715dd7e => 159
	i32 2806116107, ; 431: es/Microsoft.Maui.Controls.resources.dll => 0xa741ef0b => 296
	i32 2806395456, ; 432: Apache.NMS.ActiveMQ => 0xa7463240 => 174
	i32 2810250172, ; 433: Xamarin.AndroidX.CoordinatorLayout.dll => 0xa78103bc => 227
	i32 2819470561, ; 434: System.Xml.dll => 0xa80db4e1 => 163
	i32 2821205001, ; 435: System.ServiceProcess.dll => 0xa8282c09 => 132
	i32 2821294376, ; 436: Xamarin.AndroidX.ResourceInspection.Annotation => 0xa8298928 => 262
	i32 2824502124, ; 437: System.Xml.XmlDocument => 0xa85a7b6c => 161
	i32 2831556043, ; 438: nl/Microsoft.Maui.Controls.resources.dll => 0xa8c61dcb => 309
	i32 2838993487, ; 439: Xamarin.AndroidX.Lifecycle.ViewModel.Ktx.dll => 0xa9379a4f => 251
	i32 2849599387, ; 440: System.Threading.Overlapped.dll => 0xa9d96f9b => 140
	i32 2853208004, ; 441: Xamarin.AndroidX.ViewPager => 0xaa107fc4 => 274
	i32 2855708567, ; 442: Xamarin.AndroidX.Transition => 0xaa36a797 => 270
	i32 2861098320, ; 443: Mono.Android.Export.dll => 0xaa88e550 => 169
	i32 2861189240, ; 444: Microsoft.Maui.Essentials => 0xaa8a4878 => 197
	i32 2870099610, ; 445: Xamarin.AndroidX.Activity.Ktx.dll => 0xab123e9a => 212
	i32 2875164099, ; 446: Jsr305Binding.dll => 0xab5f85c3 => 279
	i32 2875220617, ; 447: System.Globalization.Calendars.dll => 0xab606289 => 40
	i32 2884993177, ; 448: Xamarin.AndroidX.ExifInterface => 0xabf58099 => 238
	i32 2887636118, ; 449: System.Net.dll => 0xac1dd496 => 81
	i32 2891012757, ; 450: StompNet => 0xac515a95 => 203
	i32 2899753641, ; 451: System.IO.UnmanagedMemoryStream => 0xacd6baa9 => 56
	i32 2900621748, ; 452: System.Dynamic.Runtime.dll => 0xace3f9b4 => 37
	i32 2901442782, ; 453: System.Reflection => 0xacf080de => 97
	i32 2905242038, ; 454: mscorlib.dll => 0xad2a79b6 => 166
	i32 2909740682, ; 455: System.Private.CoreLib => 0xad6f1e8a => 172
	i32 2916838712, ; 456: Xamarin.AndroidX.ViewPager2.dll => 0xaddb6d38 => 275
	i32 2919462931, ; 457: System.Numerics.Vectors.dll => 0xae037813 => 82
	i32 2921128767, ; 458: Xamarin.AndroidX.Annotation.Experimental.dll => 0xae1ce33f => 214
	i32 2936416060, ; 459: System.Resources.Reader => 0xaf06273c => 98
	i32 2940926066, ; 460: System.Diagnostics.StackTrace.dll => 0xaf4af872 => 30
	i32 2942453041, ; 461: System.Xml.XPath.XDocument => 0xaf624531 => 159
	i32 2959614098, ; 462: System.ComponentModel.dll => 0xb0682092 => 18
	i32 2968338931, ; 463: System.Security.Principal.Windows => 0xb0ed41f3 => 127
	i32 2972252294, ; 464: System.Security.Cryptography.Algorithms.dll => 0xb128f886 => 119
	i32 2978675010, ; 465: Xamarin.AndroidX.DrawerLayout => 0xb18af942 => 234
	i32 2987532451, ; 466: Xamarin.AndroidX.Security.SecurityCrypto => 0xb21220a3 => 265
	i32 2996846495, ; 467: Xamarin.AndroidX.Lifecycle.Process.dll => 0xb2a03f9f => 247
	i32 3016983068, ; 468: Xamarin.AndroidX.Startup.StartupRuntime => 0xb3d3821c => 267
	i32 3023353419, ; 469: WindowsBase.dll => 0xb434b64b => 165
	i32 3024354802, ; 470: Xamarin.AndroidX.Legacy.Support.Core.Utils => 0xb443fdf2 => 242
	i32 3038032645, ; 471: _Microsoft.Android.Resource.Designer.dll => 0xb514b305 => 324
	i32 3056245963, ; 472: Xamarin.AndroidX.SavedState.SavedState.Ktx => 0xb62a9ccb => 264
	i32 3057625584, ; 473: Xamarin.AndroidX.Navigation.Common => 0xb63fa9f0 => 255
	i32 3059408633, ; 474: Mono.Android.Runtime => 0xb65adef9 => 170
	i32 3059793426, ; 475: System.ComponentModel.Primitives => 0xb660be12 => 16
	i32 3075834255, ; 476: System.Threading.Tasks => 0xb755818f => 144
	i32 3077302341, ; 477: hu/Microsoft.Maui.Controls.resources.dll => 0xb76be845 => 302
	i32 3084678329, ; 478: Microsoft.IdentityModel.Tokens => 0xb7dc74b9 => 192
	i32 3090735792, ; 479: System.Security.Cryptography.X509Certificates.dll => 0xb838e2b0 => 125
	i32 3099732863, ; 480: System.Security.Claims.dll => 0xb8c22b7f => 118
	i32 3103600923, ; 481: System.Formats.Asn1 => 0xb8fd311b => 38
	i32 3111772706, ; 482: System.Runtime.Serialization => 0xb979e222 => 115
	i32 3121463068, ; 483: System.IO.FileSystem.AccessControl.dll => 0xba0dbf1c => 47
	i32 3124832203, ; 484: System.Threading.Tasks.Extensions => 0xba4127cb => 142
	i32 3132293585, ; 485: System.Security.AccessControl => 0xbab301d1 => 117
	i32 3135029042, ; 486: ICSharpCode.SharpZipLib.dll => 0xbadcbf32 => 201
	i32 3147165239, ; 487: System.Diagnostics.Tracing.dll => 0xbb95ee37 => 34
	i32 3148237826, ; 488: GoogleGson.dll => 0xbba64c02 => 176
	i32 3159123045, ; 489: System.Reflection.Primitives.dll => 0xbc4c6465 => 95
	i32 3160747431, ; 490: System.IO.MemoryMappedFiles => 0xbc652da7 => 53
	i32 3178803400, ; 491: Xamarin.AndroidX.Navigation.Fragment.dll => 0xbd78b0c8 => 256
	i32 3192346100, ; 492: System.Security.SecureString => 0xbe4755f4 => 129
	i32 3193515020, ; 493: System.Web => 0xbe592c0c => 153
	i32 3204380047, ; 494: System.Data.dll => 0xbefef58f => 24
	i32 3209718065, ; 495: System.Xml.XmlDocument.dll => 0xbf506931 => 161
	i32 3211777861, ; 496: Xamarin.AndroidX.DocumentFile => 0xbf6fd745 => 233
	i32 3220365878, ; 497: System.Threading => 0xbff2e236 => 148
	i32 3226221578, ; 498: System.Runtime.Handles.dll => 0xc04c3c0a => 104
	i32 3251039220, ; 499: System.Reflection.DispatchProxy.dll => 0xc1c6ebf4 => 89
	i32 3258312781, ; 500: Xamarin.AndroidX.CardView => 0xc235e84d => 221
	i32 3265493905, ; 501: System.Linq.Queryable.dll => 0xc2a37b91 => 60
	i32 3265893370, ; 502: System.Threading.Tasks.Extensions.dll => 0xc2a993fa => 142
	i32 3277815716, ; 503: System.Resources.Writer.dll => 0xc35f7fa4 => 100
	i32 3279906254, ; 504: Microsoft.Win32.Registry.dll => 0xc37f65ce => 5
	i32 3280506390, ; 505: System.ComponentModel.Annotations.dll => 0xc3888e16 => 13
	i32 3290767353, ; 506: System.Security.Cryptography.Encoding => 0xc4251ff9 => 122
	i32 3299363146, ; 507: System.Text.Encoding => 0xc4a8494a => 135
	i32 3303498502, ; 508: System.Diagnostics.FileVersionInfo => 0xc4e76306 => 28
	i32 3305363605, ; 509: fi\Microsoft.Maui.Controls.resources => 0xc503d895 => 297
	i32 3312457198, ; 510: Microsoft.IdentityModel.JsonWebTokens => 0xc57015ee => 190
	i32 3316684772, ; 511: System.Net.Requests.dll => 0xc5b097e4 => 72
	i32 3317135071, ; 512: Xamarin.AndroidX.CustomView.dll => 0xc5b776df => 231
	i32 3317144872, ; 513: System.Data => 0xc5b79d28 => 24
	i32 3340431453, ; 514: Xamarin.AndroidX.Arch.Core.Runtime => 0xc71af05d => 219
	i32 3345895724, ; 515: Xamarin.AndroidX.ProfileInstaller.ProfileInstaller.dll => 0xc76e512c => 260
	i32 3346324047, ; 516: Xamarin.AndroidX.Navigation.Runtime => 0xc774da4f => 257
	i32 3357674450, ; 517: ru\Microsoft.Maui.Controls.resources => 0xc8220bd2 => 314
	i32 3358260929, ; 518: System.Text.Json => 0xc82afec1 => 137
	i32 3362336904, ; 519: Xamarin.AndroidX.Activity.Ktx => 0xc8693088 => 212
	i32 3362522851, ; 520: Xamarin.AndroidX.Core => 0xc86c06e3 => 228
	i32 3366347497, ; 521: Java.Interop => 0xc8a662e9 => 168
	i32 3374999561, ; 522: Xamarin.AndroidX.RecyclerView => 0xc92a6809 => 261
	i32 3381016424, ; 523: da\Microsoft.Maui.Controls.resources => 0xc9863768 => 293
	i32 3381829691, ; 524: SuperSocket.ClientEngine => 0xc992a03b => 204
	i32 3395150330, ; 525: System.Runtime.CompilerServices.Unsafe.dll => 0xca5de1fa => 101
	i32 3403906625, ; 526: System.Security.Cryptography.OpenSsl.dll => 0xcae37e41 => 123
	i32 3405233483, ; 527: Xamarin.AndroidX.CustomView.PoolingContainer => 0xcaf7bd4b => 232
	i32 3422621607, ; 528: Social network => 0xcc010fa7 => 0
	i32 3426122537, ; 529: Stomp.Net => 0xcc367b29 => 202
	i32 3428513518, ; 530: Microsoft.Extensions.DependencyInjection.dll => 0xcc5af6ee => 182
	i32 3429136800, ; 531: System.Xml => 0xcc6479a0 => 163
	i32 3430777524, ; 532: netstandard => 0xcc7d82b4 => 167
	i32 3437289905, ; 533: IdentityModel.OidcClient.IdentityTokenValidator => 0xcce0e1b1 => 179
	i32 3441283291, ; 534: Xamarin.AndroidX.DynamicAnimation.dll => 0xcd1dd0db => 235
	i32 3445260447, ; 535: System.Formats.Tar => 0xcd5a809f => 39
	i32 3452344032, ; 536: Microsoft.Maui.Controls.Compatibility.dll => 0xcdc696e0 => 193
	i32 3463511458, ; 537: hr/Microsoft.Maui.Controls.resources.dll => 0xce70fda2 => 301
	i32 3471940407, ; 538: System.ComponentModel.TypeConverter.dll => 0xcef19b37 => 17
	i32 3476120550, ; 539: Mono.Android => 0xcf3163e6 => 171
	i32 3479583265, ; 540: ru/Microsoft.Maui.Controls.resources.dll => 0xcf663a21 => 314
	i32 3484440000, ; 541: ro\Microsoft.Maui.Controls.resources => 0xcfb055c0 => 313
	i32 3485117614, ; 542: System.Text.Json.dll => 0xcfbaacae => 137
	i32 3486566296, ; 543: System.Transactions => 0xcfd0c798 => 150
	i32 3493954962, ; 544: Xamarin.AndroidX.Concurrent.Futures.dll => 0xd0418592 => 224
	i32 3509114376, ; 545: System.Xml.Linq => 0xd128d608 => 155
	i32 3515174580, ; 546: System.Security.dll => 0xd1854eb4 => 130
	i32 3530912306, ; 547: System.Configuration => 0xd2757232 => 19
	i32 3539954161, ; 548: System.Net.HttpListener => 0xd2ff69f1 => 65
	i32 3560100363, ; 549: System.Threading.Timer => 0xd432d20b => 147
	i32 3570554715, ; 550: System.IO.FileSystem.AccessControl => 0xd4d2575b => 47
	i32 3580758918, ; 551: zh-HK\Microsoft.Maui.Controls.resources => 0xd56e0b86 => 321
	i32 3597029428, ; 552: Xamarin.Android.Glide.GifDecoder.dll => 0xd6665034 => 210
	i32 3598340787, ; 553: System.Net.WebSockets.Client => 0xd67a52b3 => 79
	i32 3608519521, ; 554: System.Linq.dll => 0xd715a361 => 61
	i32 3624195450, ; 555: System.Runtime.InteropServices.RuntimeInformation => 0xd804d57a => 106
	i32 3627220390, ; 556: Xamarin.AndroidX.Print.dll => 0xd832fda6 => 259
	i32 3633644679, ; 557: Xamarin.AndroidX.Annotation.Experimental => 0xd8950487 => 214
	i32 3638274909, ; 558: System.IO.FileSystem.Primitives.dll => 0xd8dbab5d => 49
	i32 3641597786, ; 559: Xamarin.AndroidX.Lifecycle.LiveData.Core => 0xd90e5f5a => 245
	i32 3643446276, ; 560: tr\Microsoft.Maui.Controls.resources => 0xd92a9404 => 318
	i32 3643854240, ; 561: Xamarin.AndroidX.Navigation.Fragment => 0xd930cda0 => 256
	i32 3645089577, ; 562: System.ComponentModel.DataAnnotations => 0xd943a729 => 14
	i32 3654326742, ; 563: Microsoft.Toolkit.Mvvm.dll => 0xd9d099d6 => 199
	i32 3657292374, ; 564: Microsoft.Extensions.Configuration.Abstractions.dll => 0xd9fdda56 => 181
	i32 3660523487, ; 565: System.Net.NetworkInformation => 0xda2f27df => 68
	i32 3672681054, ; 566: Mono.Android.dll => 0xdae8aa5e => 171
	i32 3682565725, ; 567: Xamarin.AndroidX.Browser => 0xdb7f7e5d => 220
	i32 3684561358, ; 568: Xamarin.AndroidX.Concurrent.Futures => 0xdb9df1ce => 224
	i32 3697841164, ; 569: zh-Hant/Microsoft.Maui.Controls.resources.dll => 0xdc68940c => 323
	i32 3700591436, ; 570: Microsoft.IdentityModel.Abstractions.dll => 0xdc928b4c => 189
	i32 3700866549, ; 571: System.Net.WebProxy.dll => 0xdc96bdf5 => 78
	i32 3706696989, ; 572: Xamarin.AndroidX.Core.Core.Ktx.dll => 0xdcefb51d => 229
	i32 3716563718, ; 573: System.Runtime.Intrinsics => 0xdd864306 => 108
	i32 3718780102, ; 574: Xamarin.AndroidX.Annotation => 0xdda814c6 => 213
	i32 3724253651, ; 575: Apache.NMS.ActiveMQ.dll => 0xddfb99d3 => 174
	i32 3724971120, ; 576: Xamarin.AndroidX.Navigation.Common.dll => 0xde068c70 => 255
	i32 3732100267, ; 577: System.Net.NameResolution => 0xde7354ab => 67
	i32 3737834244, ; 578: System.Net.Http.Json.dll => 0xdecad304 => 63
	i32 3748608112, ; 579: System.Diagnostics.DiagnosticSource => 0xdf6f3870 => 27
	i32 3751444290, ; 580: System.Xml.XPath => 0xdf9a7f42 => 160
	i32 3786282454, ; 581: Xamarin.AndroidX.Collection => 0xe1ae15d6 => 222
	i32 3792276235, ; 582: System.Collections.NonGeneric => 0xe2098b0b => 10
	i32 3800979733, ; 583: Microsoft.Maui.Controls.Compatibility => 0xe28e5915 => 193
	i32 3802395368, ; 584: System.Collections.Specialized.dll => 0xe2a3f2e8 => 11
	i32 3819260425, ; 585: System.Net.WebProxy => 0xe3a54a09 => 78
	i32 3823082795, ; 586: System.Security.Cryptography.dll => 0xe3df9d2b => 126
	i32 3829621856, ; 587: System.Numerics.dll => 0xe4436460 => 83
	i32 3841636137, ; 588: Microsoft.Extensions.DependencyInjection.Abstractions.dll => 0xe4fab729 => 183
	i32 3844307129, ; 589: System.Net.Mail.dll => 0xe52378b9 => 66
	i32 3849253459, ; 590: System.Runtime.InteropServices.dll => 0xe56ef253 => 107
	i32 3849856203, ; 591: SuperSocket.ClientEngine.dll => 0xe57824cb => 204
	i32 3870376305, ; 592: System.Net.HttpListener.dll => 0xe6b14171 => 65
	i32 3873536506, ; 593: System.Security.Principal => 0xe6e179fa => 128
	i32 3875112723, ; 594: System.Security.Cryptography.Encoding.dll => 0xe6f98713 => 122
	i32 3885497537, ; 595: System.Net.WebHeaderCollection.dll => 0xe797fcc1 => 77
	i32 3885922214, ; 596: Xamarin.AndroidX.Transition.dll => 0xe79e77a6 => 270
	i32 3888767677, ; 597: Xamarin.AndroidX.ProfileInstaller.ProfileInstaller => 0xe7c9e2bd => 260
	i32 3889960447, ; 598: zh-Hans/Microsoft.Maui.Controls.resources.dll => 0xe7dc15ff => 322
	i32 3896106733, ; 599: System.Collections.Concurrent.dll => 0xe839deed => 8
	i32 3896760992, ; 600: Xamarin.AndroidX.Core.dll => 0xe843daa0 => 228
	i32 3901907137, ; 601: Microsoft.VisualBasic.Core.dll => 0xe89260c1 => 2
	i32 3920810846, ; 602: System.IO.Compression.FileSystem.dll => 0xe9b2d35e => 44
	i32 3921031405, ; 603: Xamarin.AndroidX.VersionedParcelable.dll => 0xe9b630ed => 273
	i32 3928044579, ; 604: System.Xml.ReaderWriter => 0xea213423 => 156
	i32 3930554604, ; 605: System.Security.Principal.dll => 0xea4780ec => 128
	i32 3931092270, ; 606: Xamarin.AndroidX.Navigation.UI => 0xea4fb52e => 258
	i32 3945713374, ; 607: System.Data.DataSetExtensions.dll => 0xeb2ecede => 23
	i32 3953953790, ; 608: System.Text.Encoding.CodePages => 0xebac8bfe => 133
	i32 3955647286, ; 609: Xamarin.AndroidX.AppCompat.dll => 0xebc66336 => 216
	i32 3959773229, ; 610: Xamarin.AndroidX.Lifecycle.Process => 0xec05582d => 247
	i32 3980434154, ; 611: th/Microsoft.Maui.Controls.resources.dll => 0xed409aea => 317
	i32 3987592930, ; 612: he/Microsoft.Maui.Controls.resources.dll => 0xedadd6e2 => 299
	i32 4003436829, ; 613: System.Diagnostics.Process.dll => 0xee9f991d => 29
	i32 4015948917, ; 614: Xamarin.AndroidX.Annotation.Jvm.dll => 0xef5e8475 => 215
	i32 4025784931, ; 615: System.Memory => 0xeff49a63 => 62
	i32 4044257358, ; 616: IdentityModel.dll => 0xf10e784e => 177
	i32 4046471985, ; 617: Microsoft.Maui.Controls.Xaml.dll => 0xf1304331 => 195
	i32 4054681211, ; 618: System.Reflection.Emit.ILGeneration => 0xf1ad867b => 90
	i32 4068434129, ; 619: System.Private.Xml.Linq.dll => 0xf27f60d1 => 87
	i32 4073602200, ; 620: System.Threading.dll => 0xf2ce3c98 => 148
	i32 4094352644, ; 621: Microsoft.Maui.Essentials.dll => 0xf40add04 => 197
	i32 4099507663, ; 622: System.Drawing.dll => 0xf45985cf => 36
	i32 4100113165, ; 623: System.Private.Uri => 0xf462c30d => 86
	i32 4101593132, ; 624: Xamarin.AndroidX.Emoji2 => 0xf479582c => 236
	i32 4102112229, ; 625: pt/Microsoft.Maui.Controls.resources.dll => 0xf48143e5 => 312
	i32 4125707920, ; 626: ms/Microsoft.Maui.Controls.resources.dll => 0xf5e94e90 => 307
	i32 4126470640, ; 627: Microsoft.Extensions.DependencyInjection => 0xf5f4f1f0 => 182
	i32 4127667938, ; 628: System.IO.FileSystem.Watcher => 0xf60736e2 => 50
	i32 4130442656, ; 629: System.AppContext => 0xf6318da0 => 6
	i32 4147896353, ; 630: System.Reflection.Emit.ILGeneration.dll => 0xf73be021 => 90
	i32 4150914736, ; 631: uk\Microsoft.Maui.Controls.resources => 0xf769eeb0 => 319
	i32 4151237749, ; 632: System.Core => 0xf76edc75 => 21
	i32 4152369130, ; 633: IdentityModel.OidcClient => 0xf7801fea => 178
	i32 4159265925, ; 634: System.Xml.XmlSerializer => 0xf7e95c85 => 162
	i32 4161255271, ; 635: System.Reflection.TypeExtensions => 0xf807b767 => 96
	i32 4164802419, ; 636: System.IO.FileSystem.Watcher.dll => 0xf83dd773 => 50
	i32 4181436372, ; 637: System.Runtime.Serialization.Primitives => 0xf93ba7d4 => 113
	i32 4182413190, ; 638: Xamarin.AndroidX.Lifecycle.ViewModelSavedState.dll => 0xf94a8f86 => 252
	i32 4185676441, ; 639: System.Security => 0xf97c5a99 => 130
	i32 4196529839, ; 640: System.Net.WebClient.dll => 0xfa21f6af => 76
	i32 4213026141, ; 641: System.Diagnostics.DiagnosticSource.dll => 0xfb1dad5d => 27
	i32 4256097574, ; 642: Xamarin.AndroidX.Core.Core.Ktx => 0xfdaee526 => 229
	i32 4258378803, ; 643: Xamarin.AndroidX.Lifecycle.ViewModel.Ktx => 0xfdd1b433 => 251
	i32 4260525087, ; 644: System.Buffers => 0xfdf2741f => 7
	i32 4263231520, ; 645: System.IdentityModel.Tokens.Jwt.dll => 0xfe1bc020 => 205
	i32 4271975918, ; 646: Microsoft.Maui.Controls.dll => 0xfea12dee => 194
	i32 4274976490, ; 647: System.Runtime.Numerics => 0xfecef6ea => 110
	i32 4292120959, ; 648: Xamarin.AndroidX.Lifecycle.ViewModelSavedState => 0xffd4917f => 252
	i32 4294763496 ; 649: Xamarin.AndroidX.ExifInterface.dll => 0xfffce3e8 => 238
], align 4

@assembly_image_cache_indices = dso_local local_unnamed_addr constant [650 x i32] [
	i32 68, ; 0
	i32 173, ; 1
	i32 67, ; 2
	i32 108, ; 3
	i32 248, ; 4
	i32 282, ; 5
	i32 48, ; 6
	i32 200, ; 7
	i32 80, ; 8
	i32 145, ; 9
	i32 30, ; 10
	i32 323, ; 11
	i32 124, ; 12
	i32 198, ; 13
	i32 102, ; 14
	i32 266, ; 15
	i32 107, ; 16
	i32 266, ; 17
	i32 139, ; 18
	i32 201, ; 19
	i32 0, ; 20
	i32 286, ; 21
	i32 77, ; 22
	i32 124, ; 23
	i32 13, ; 24
	i32 222, ; 25
	i32 132, ; 26
	i32 203, ; 27
	i32 268, ; 28
	i32 151, ; 29
	i32 320, ; 30
	i32 321, ; 31
	i32 18, ; 32
	i32 206, ; 33
	i32 220, ; 34
	i32 26, ; 35
	i32 242, ; 36
	i32 1, ; 37
	i32 59, ; 38
	i32 42, ; 39
	i32 91, ; 40
	i32 225, ; 41
	i32 179, ; 42
	i32 147, ; 43
	i32 244, ; 44
	i32 241, ; 45
	i32 292, ; 46
	i32 54, ; 47
	i32 69, ; 48
	i32 320, ; 49
	i32 211, ; 50
	i32 83, ; 51
	i32 305, ; 52
	i32 243, ; 53
	i32 304, ; 54
	i32 131, ; 55
	i32 55, ; 56
	i32 149, ; 57
	i32 74, ; 58
	i32 145, ; 59
	i32 62, ; 60
	i32 146, ; 61
	i32 324, ; 62
	i32 165, ; 63
	i32 316, ; 64
	i32 226, ; 65
	i32 12, ; 66
	i32 239, ; 67
	i32 125, ; 68
	i32 152, ; 69
	i32 113, ; 70
	i32 166, ; 71
	i32 164, ; 72
	i32 241, ; 73
	i32 189, ; 74
	i32 254, ; 75
	i32 84, ; 76
	i32 303, ; 77
	i32 297, ; 78
	i32 175, ; 79
	i32 188, ; 80
	i32 150, ; 81
	i32 286, ; 82
	i32 60, ; 83
	i32 184, ; 84
	i32 51, ; 85
	i32 103, ; 86
	i32 114, ; 87
	i32 40, ; 88
	i32 202, ; 89
	i32 279, ; 90
	i32 277, ; 91
	i32 120, ; 92
	i32 311, ; 93
	i32 52, ; 94
	i32 44, ; 95
	i32 119, ; 96
	i32 231, ; 97
	i32 309, ; 98
	i32 237, ; 99
	i32 81, ; 100
	i32 136, ; 101
	i32 273, ; 102
	i32 218, ; 103
	i32 8, ; 104
	i32 73, ; 105
	i32 291, ; 106
	i32 155, ; 107
	i32 288, ; 108
	i32 154, ; 109
	i32 92, ; 110
	i32 283, ; 111
	i32 45, ; 112
	i32 306, ; 113
	i32 294, ; 114
	i32 287, ; 115
	i32 109, ; 116
	i32 129, ; 117
	i32 25, ; 118
	i32 208, ; 119
	i32 72, ; 120
	i32 55, ; 121
	i32 46, ; 122
	i32 315, ; 123
	i32 187, ; 124
	i32 232, ; 125
	i32 22, ; 126
	i32 246, ; 127
	i32 86, ; 128
	i32 43, ; 129
	i32 160, ; 130
	i32 71, ; 131
	i32 259, ; 132
	i32 3, ; 133
	i32 42, ; 134
	i32 63, ; 135
	i32 178, ; 136
	i32 16, ; 137
	i32 53, ; 138
	i32 318, ; 139
	i32 282, ; 140
	i32 105, ; 141
	i32 200, ; 142
	i32 287, ; 143
	i32 280, ; 144
	i32 243, ; 145
	i32 34, ; 146
	i32 158, ; 147
	i32 85, ; 148
	i32 32, ; 149
	i32 12, ; 150
	i32 51, ; 151
	i32 56, ; 152
	i32 263, ; 153
	i32 36, ; 154
	i32 183, ; 155
	i32 293, ; 156
	i32 281, ; 157
	i32 216, ; 158
	i32 35, ; 159
	i32 58, ; 160
	i32 250, ; 161
	i32 176, ; 162
	i32 17, ; 163
	i32 284, ; 164
	i32 164, ; 165
	i32 306, ; 166
	i32 249, ; 167
	i32 186, ; 168
	i32 276, ; 169
	i32 312, ; 170
	i32 153, ; 171
	i32 272, ; 172
	i32 257, ; 173
	i32 310, ; 174
	i32 218, ; 175
	i32 29, ; 176
	i32 52, ; 177
	i32 308, ; 178
	i32 277, ; 179
	i32 5, ; 180
	i32 292, ; 181
	i32 267, ; 182
	i32 271, ; 183
	i32 223, ; 184
	i32 288, ; 185
	i32 215, ; 186
	i32 234, ; 187
	i32 85, ; 188
	i32 206, ; 189
	i32 276, ; 190
	i32 61, ; 191
	i32 112, ; 192
	i32 57, ; 193
	i32 322, ; 194
	i32 263, ; 195
	i32 99, ; 196
	i32 19, ; 197
	i32 227, ; 198
	i32 111, ; 199
	i32 101, ; 200
	i32 102, ; 201
	i32 290, ; 202
	i32 104, ; 203
	i32 280, ; 204
	i32 71, ; 205
	i32 38, ; 206
	i32 32, ; 207
	i32 103, ; 208
	i32 73, ; 209
	i32 205, ; 210
	i32 296, ; 211
	i32 9, ; 212
	i32 123, ; 213
	i32 46, ; 214
	i32 217, ; 215
	i32 188, ; 216
	i32 9, ; 217
	i32 43, ; 218
	i32 4, ; 219
	i32 264, ; 220
	i32 300, ; 221
	i32 190, ; 222
	i32 295, ; 223
	i32 31, ; 224
	i32 138, ; 225
	i32 92, ; 226
	i32 93, ; 227
	i32 315, ; 228
	i32 49, ; 229
	i32 141, ; 230
	i32 112, ; 231
	i32 140, ; 232
	i32 233, ; 233
	i32 115, ; 234
	i32 281, ; 235
	i32 157, ; 236
	i32 76, ; 237
	i32 79, ; 238
	i32 253, ; 239
	i32 37, ; 240
	i32 275, ; 241
	i32 237, ; 242
	i32 230, ; 243
	i32 64, ; 244
	i32 138, ; 245
	i32 15, ; 246
	i32 116, ; 247
	i32 269, ; 248
	i32 278, ; 249
	i32 225, ; 250
	i32 48, ; 251
	i32 70, ; 252
	i32 80, ; 253
	i32 126, ; 254
	i32 94, ; 255
	i32 121, ; 256
	i32 285, ; 257
	i32 26, ; 258
	i32 246, ; 259
	i32 97, ; 260
	i32 28, ; 261
	i32 221, ; 262
	i32 313, ; 263
	i32 291, ; 264
	i32 149, ; 265
	i32 169, ; 266
	i32 4, ; 267
	i32 98, ; 268
	i32 33, ; 269
	i32 93, ; 270
	i32 268, ; 271
	i32 184, ; 272
	i32 21, ; 273
	i32 41, ; 274
	i32 170, ; 275
	i32 307, ; 276
	i32 239, ; 277
	i32 299, ; 278
	i32 253, ; 279
	i32 284, ; 280
	i32 278, ; 281
	i32 258, ; 282
	i32 2, ; 283
	i32 134, ; 284
	i32 111, ; 285
	i32 185, ; 286
	i32 319, ; 287
	i32 208, ; 288
	i32 316, ; 289
	i32 58, ; 290
	i32 95, ; 291
	i32 177, ; 292
	i32 298, ; 293
	i32 39, ; 294
	i32 219, ; 295
	i32 25, ; 296
	i32 94, ; 297
	i32 89, ; 298
	i32 99, ; 299
	i32 10, ; 300
	i32 87, ; 301
	i32 100, ; 302
	i32 265, ; 303
	i32 180, ; 304
	i32 285, ; 305
	i32 210, ; 306
	i32 192, ; 307
	i32 295, ; 308
	i32 7, ; 309
	i32 250, ; 310
	i32 290, ; 311
	i32 207, ; 312
	i32 88, ; 313
	i32 245, ; 314
	i32 154, ; 315
	i32 294, ; 316
	i32 33, ; 317
	i32 116, ; 318
	i32 82, ; 319
	i32 20, ; 320
	i32 11, ; 321
	i32 162, ; 322
	i32 3, ; 323
	i32 196, ; 324
	i32 302, ; 325
	i32 187, ; 326
	i32 185, ; 327
	i32 84, ; 328
	i32 289, ; 329
	i32 64, ; 330
	i32 304, ; 331
	i32 272, ; 332
	i32 143, ; 333
	i32 254, ; 334
	i32 157, ; 335
	i32 41, ; 336
	i32 117, ; 337
	i32 181, ; 338
	i32 209, ; 339
	i32 298, ; 340
	i32 261, ; 341
	i32 131, ; 342
	i32 75, ; 343
	i32 66, ; 344
	i32 308, ; 345
	i32 172, ; 346
	i32 213, ; 347
	i32 143, ; 348
	i32 173, ; 349
	i32 106, ; 350
	i32 151, ; 351
	i32 70, ; 352
	i32 156, ; 353
	i32 191, ; 354
	i32 180, ; 355
	i32 121, ; 356
	i32 127, ; 357
	i32 303, ; 358
	i32 152, ; 359
	i32 236, ; 360
	i32 141, ; 361
	i32 223, ; 362
	i32 300, ; 363
	i32 20, ; 364
	i32 14, ; 365
	i32 135, ; 366
	i32 75, ; 367
	i32 59, ; 368
	i32 226, ; 369
	i32 167, ; 370
	i32 168, ; 371
	i32 194, ; 372
	i32 15, ; 373
	i32 74, ; 374
	i32 6, ; 375
	i32 199, ; 376
	i32 23, ; 377
	i32 248, ; 378
	i32 207, ; 379
	i32 91, ; 380
	i32 301, ; 381
	i32 1, ; 382
	i32 136, ; 383
	i32 249, ; 384
	i32 271, ; 385
	i32 134, ; 386
	i32 69, ; 387
	i32 146, ; 388
	i32 310, ; 389
	i32 289, ; 390
	i32 240, ; 391
	i32 186, ; 392
	i32 88, ; 393
	i32 96, ; 394
	i32 230, ; 395
	i32 235, ; 396
	i32 305, ; 397
	i32 31, ; 398
	i32 45, ; 399
	i32 244, ; 400
	i32 191, ; 401
	i32 209, ; 402
	i32 109, ; 403
	i32 158, ; 404
	i32 35, ; 405
	i32 22, ; 406
	i32 114, ; 407
	i32 57, ; 408
	i32 269, ; 409
	i32 144, ; 410
	i32 118, ; 411
	i32 120, ; 412
	i32 110, ; 413
	i32 211, ; 414
	i32 139, ; 415
	i32 217, ; 416
	i32 54, ; 417
	i32 105, ; 418
	i32 311, ; 419
	i32 195, ; 420
	i32 196, ; 421
	i32 133, ; 422
	i32 283, ; 423
	i32 274, ; 424
	i32 262, ; 425
	i32 317, ; 426
	i32 240, ; 427
	i32 175, ; 428
	i32 198, ; 429
	i32 159, ; 430
	i32 296, ; 431
	i32 174, ; 432
	i32 227, ; 433
	i32 163, ; 434
	i32 132, ; 435
	i32 262, ; 436
	i32 161, ; 437
	i32 309, ; 438
	i32 251, ; 439
	i32 140, ; 440
	i32 274, ; 441
	i32 270, ; 442
	i32 169, ; 443
	i32 197, ; 444
	i32 212, ; 445
	i32 279, ; 446
	i32 40, ; 447
	i32 238, ; 448
	i32 81, ; 449
	i32 203, ; 450
	i32 56, ; 451
	i32 37, ; 452
	i32 97, ; 453
	i32 166, ; 454
	i32 172, ; 455
	i32 275, ; 456
	i32 82, ; 457
	i32 214, ; 458
	i32 98, ; 459
	i32 30, ; 460
	i32 159, ; 461
	i32 18, ; 462
	i32 127, ; 463
	i32 119, ; 464
	i32 234, ; 465
	i32 265, ; 466
	i32 247, ; 467
	i32 267, ; 468
	i32 165, ; 469
	i32 242, ; 470
	i32 324, ; 471
	i32 264, ; 472
	i32 255, ; 473
	i32 170, ; 474
	i32 16, ; 475
	i32 144, ; 476
	i32 302, ; 477
	i32 192, ; 478
	i32 125, ; 479
	i32 118, ; 480
	i32 38, ; 481
	i32 115, ; 482
	i32 47, ; 483
	i32 142, ; 484
	i32 117, ; 485
	i32 201, ; 486
	i32 34, ; 487
	i32 176, ; 488
	i32 95, ; 489
	i32 53, ; 490
	i32 256, ; 491
	i32 129, ; 492
	i32 153, ; 493
	i32 24, ; 494
	i32 161, ; 495
	i32 233, ; 496
	i32 148, ; 497
	i32 104, ; 498
	i32 89, ; 499
	i32 221, ; 500
	i32 60, ; 501
	i32 142, ; 502
	i32 100, ; 503
	i32 5, ; 504
	i32 13, ; 505
	i32 122, ; 506
	i32 135, ; 507
	i32 28, ; 508
	i32 297, ; 509
	i32 190, ; 510
	i32 72, ; 511
	i32 231, ; 512
	i32 24, ; 513
	i32 219, ; 514
	i32 260, ; 515
	i32 257, ; 516
	i32 314, ; 517
	i32 137, ; 518
	i32 212, ; 519
	i32 228, ; 520
	i32 168, ; 521
	i32 261, ; 522
	i32 293, ; 523
	i32 204, ; 524
	i32 101, ; 525
	i32 123, ; 526
	i32 232, ; 527
	i32 0, ; 528
	i32 202, ; 529
	i32 182, ; 530
	i32 163, ; 531
	i32 167, ; 532
	i32 179, ; 533
	i32 235, ; 534
	i32 39, ; 535
	i32 193, ; 536
	i32 301, ; 537
	i32 17, ; 538
	i32 171, ; 539
	i32 314, ; 540
	i32 313, ; 541
	i32 137, ; 542
	i32 150, ; 543
	i32 224, ; 544
	i32 155, ; 545
	i32 130, ; 546
	i32 19, ; 547
	i32 65, ; 548
	i32 147, ; 549
	i32 47, ; 550
	i32 321, ; 551
	i32 210, ; 552
	i32 79, ; 553
	i32 61, ; 554
	i32 106, ; 555
	i32 259, ; 556
	i32 214, ; 557
	i32 49, ; 558
	i32 245, ; 559
	i32 318, ; 560
	i32 256, ; 561
	i32 14, ; 562
	i32 199, ; 563
	i32 181, ; 564
	i32 68, ; 565
	i32 171, ; 566
	i32 220, ; 567
	i32 224, ; 568
	i32 323, ; 569
	i32 189, ; 570
	i32 78, ; 571
	i32 229, ; 572
	i32 108, ; 573
	i32 213, ; 574
	i32 174, ; 575
	i32 255, ; 576
	i32 67, ; 577
	i32 63, ; 578
	i32 27, ; 579
	i32 160, ; 580
	i32 222, ; 581
	i32 10, ; 582
	i32 193, ; 583
	i32 11, ; 584
	i32 78, ; 585
	i32 126, ; 586
	i32 83, ; 587
	i32 183, ; 588
	i32 66, ; 589
	i32 107, ; 590
	i32 204, ; 591
	i32 65, ; 592
	i32 128, ; 593
	i32 122, ; 594
	i32 77, ; 595
	i32 270, ; 596
	i32 260, ; 597
	i32 322, ; 598
	i32 8, ; 599
	i32 228, ; 600
	i32 2, ; 601
	i32 44, ; 602
	i32 273, ; 603
	i32 156, ; 604
	i32 128, ; 605
	i32 258, ; 606
	i32 23, ; 607
	i32 133, ; 608
	i32 216, ; 609
	i32 247, ; 610
	i32 317, ; 611
	i32 299, ; 612
	i32 29, ; 613
	i32 215, ; 614
	i32 62, ; 615
	i32 177, ; 616
	i32 195, ; 617
	i32 90, ; 618
	i32 87, ; 619
	i32 148, ; 620
	i32 197, ; 621
	i32 36, ; 622
	i32 86, ; 623
	i32 236, ; 624
	i32 312, ; 625
	i32 307, ; 626
	i32 182, ; 627
	i32 50, ; 628
	i32 6, ; 629
	i32 90, ; 630
	i32 319, ; 631
	i32 21, ; 632
	i32 178, ; 633
	i32 162, ; 634
	i32 96, ; 635
	i32 50, ; 636
	i32 113, ; 637
	i32 252, ; 638
	i32 130, ; 639
	i32 76, ; 640
	i32 27, ; 641
	i32 229, ; 642
	i32 251, ; 643
	i32 7, ; 644
	i32 205, ; 645
	i32 194, ; 646
	i32 110, ; 647
	i32 252, ; 648
	i32 238 ; 649
], align 4

@marshal_methods_number_of_classes = dso_local local_unnamed_addr constant i32 0, align 4

@marshal_methods_class_cache = dso_local local_unnamed_addr global [0 x %struct.MarshalMethodsManagedClass] zeroinitializer, align 4

; Names of classes in which marshal methods reside
@mm_class_names = dso_local local_unnamed_addr constant [0 x ptr] zeroinitializer, align 4

@mm_method_names = dso_local local_unnamed_addr constant [1 x %struct.MarshalMethodName] [
	%struct.MarshalMethodName {
		i64 0, ; id 0x0; name: 
		ptr @.MarshalMethodName.0_name; char* name
	} ; 0
], align 8

; get_function_pointer (uint32_t mono_image_index, uint32_t class_index, uint32_t method_token, void*& target_ptr)
@get_function_pointer = internal dso_local unnamed_addr global ptr null, align 4

; Functions

; Function attributes: "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind "stack-protector-buffer-size"="8" uwtable willreturn
define void @xamarin_app_init(ptr nocapture noundef readnone %env, ptr noundef %fn) local_unnamed_addr #0
{
	%fnIsNull = icmp eq ptr %fn, null
	br i1 %fnIsNull, label %1, label %2

1: ; preds = %0
	%putsResult = call noundef i32 @puts(ptr @.str.0)
	call void @abort()
	unreachable 

2: ; preds = %1, %0
	store ptr %fn, ptr @get_function_pointer, align 4, !tbaa !3
	ret void
}

; Strings
@.str.0 = private unnamed_addr constant [40 x i8] c"get_function_pointer MUST be specified\0A\00", align 1

;MarshalMethodName
@.MarshalMethodName.0_name = private unnamed_addr constant [1 x i8] c"\00", align 1

; External functions

; Function attributes: noreturn "no-trapping-math"="true" nounwind "stack-protector-buffer-size"="8"
declare void @abort() local_unnamed_addr #2

; Function attributes: nofree nounwind
declare noundef i32 @puts(ptr noundef) local_unnamed_addr #1
attributes #0 = { "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind "stack-protector-buffer-size"="8" "stackrealign" "target-cpu"="i686" "target-features"="+cx8,+mmx,+sse,+sse2,+sse3,+ssse3,+x87" "tune-cpu"="generic" uwtable willreturn }
attributes #1 = { nofree nounwind }
attributes #2 = { noreturn "no-trapping-math"="true" nounwind "stack-protector-buffer-size"="8" "stackrealign" "target-cpu"="i686" "target-features"="+cx8,+mmx,+sse,+sse2,+sse3,+ssse3,+x87" "tune-cpu"="generic" }

; Metadata
!llvm.module.flags = !{!0, !1, !7}
!0 = !{i32 1, !"wchar_size", i32 4}
!1 = !{i32 7, !"PIC Level", i32 2}
!llvm.ident = !{!2}
!2 = !{!"Xamarin.Android remotes/origin/release/8.0.4xx @ 45bb7f365f1587a7786d5bbbf0daec075d5aabea"}
!3 = !{!4, !4, i64 0}
!4 = !{!"any pointer", !5, i64 0}
!5 = !{!"omnipotent char", !6, i64 0}
!6 = !{!"Simple C++ TBAA"}
!7 = !{i32 1, !"NumRegisterParameters", i32 0}
