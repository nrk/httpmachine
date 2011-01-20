
#line 1 "HttpParser.cs.rl"
using System;

namespace HttpMachine
{
    public class HttpParser
    {
        int cs;
        int mark;
        int qsMark;
        int fragMark;
        IHttpParserHandler parser;
        int bytesRead;

        // internal for testing
        internal int contentLength;
        internal bool gotContentLength;


        
#line 190 "HttpParser.cs.rl"

        
        
#line 27 "HttpParser.cs"
static readonly sbyte[] _http_parser_actions =  new sbyte [] {
	0, 1, 0, 1, 1, 1, 2, 1, 
	3, 1, 4, 1, 5, 1, 6, 1, 
	7, 1, 8, 1, 10, 1, 11, 1, 
	12, 1, 13, 1, 16, 1, 17, 1, 
	18, 1, 20, 2, 7, 4, 2, 7, 
	5, 2, 9, 4, 2, 9, 5, 2, 
	14, 13, 2, 15, 16, 2, 18, 19
	
};

static readonly short[] _http_parser_key_offsets =  new short [] {
	0, 0, 4, 9, 12, 15, 16, 17, 
	18, 19, 20, 22, 23, 25, 26, 27, 
	45, 46, 62, 64, 65, 83, 101, 119, 
	137, 155, 173, 189, 207, 225, 243, 261, 
	279, 297, 313, 314, 315, 317, 319, 324, 
	329, 334, 339, 344, 349, 354, 359, 364, 
	369, 374, 379, 384, 389, 394, 399, 404, 
	409, 414, 419, 424, 429, 430, 430
};

static readonly char[] _http_parser_trans_keys =  new char [] {
	'\u0041', '\u005a', '\u0061', '\u007a', '\u0020', '\u0041', '\u005a', '\u0061', 
	'\u007a', '\u0020', '\u0023', '\u003f', '\u0020', '\u0023', '\u003f', '\u0048', 
	'\u0054', '\u0054', '\u0050', '\u002f', '\u0030', '\u0039', '\u002e', '\u0030', 
	'\u0039', '\u000d', '\u000a', '\u000d', '\u0021', '\u0043', '\u0063', '\u007c', 
	'\u007e', '\u0023', '\u0027', '\u002a', '\u002b', '\u002d', '\u002e', '\u0030', 
	'\u0039', '\u0041', '\u005a', '\u005e', '\u007a', '\u000a', '\u0021', '\u003a', 
	'\u007c', '\u007e', '\u0023', '\u0027', '\u002a', '\u002b', '\u002d', '\u002e', 
	'\u0030', '\u0039', '\u0041', '\u005a', '\u005e', '\u007a', '\u0009', '\u0020', 
	'\u000d', '\u0021', '\u003a', '\u004f', '\u006f', '\u007c', '\u007e', '\u0023', 
	'\u0027', '\u002a', '\u002b', '\u002d', '\u002e', '\u0030', '\u0039', '\u0041', 
	'\u005a', '\u005e', '\u007a', '\u0021', '\u003a', '\u004e', '\u006e', '\u007c', 
	'\u007e', '\u0023', '\u0027', '\u002a', '\u002b', '\u002d', '\u002e', '\u0030', 
	'\u0039', '\u0041', '\u005a', '\u005e', '\u007a', '\u0021', '\u003a', '\u0054', 
	'\u0074', '\u007c', '\u007e', '\u0023', '\u0027', '\u002a', '\u002b', '\u002d', 
	'\u002e', '\u0030', '\u0039', '\u0041', '\u005a', '\u005e', '\u007a', '\u0021', 
	'\u003a', '\u0045', '\u0065', '\u007c', '\u007e', '\u0023', '\u0027', '\u002a', 
	'\u002b', '\u002d', '\u002e', '\u0030', '\u0039', '\u0041', '\u005a', '\u005e', 
	'\u007a', '\u0021', '\u003a', '\u004e', '\u006e', '\u007c', '\u007e', '\u0023', 
	'\u0027', '\u002a', '\u002b', '\u002d', '\u002e', '\u0030', '\u0039', '\u0041', 
	'\u005a', '\u005e', '\u007a', '\u0021', '\u003a', '\u0054', '\u0074', '\u007c', 
	'\u007e', '\u0023', '\u0027', '\u002a', '\u002b', '\u002d', '\u002e', '\u0030', 
	'\u0039', '\u0041', '\u005a', '\u005e', '\u007a', '\u0021', '\u002d', '\u002e', 
	'\u003a', '\u007c', '\u007e', '\u0023', '\u0027', '\u002a', '\u002b', '\u0030', 
	'\u0039', '\u0041', '\u005a', '\u005e', '\u007a', '\u0021', '\u003a', '\u004c', 
	'\u006c', '\u007c', '\u007e', '\u0023', '\u0027', '\u002a', '\u002b', '\u002d', 
	'\u002e', '\u0030', '\u0039', '\u0041', '\u005a', '\u005e', '\u007a', '\u0021', 
	'\u003a', '\u0045', '\u0065', '\u007c', '\u007e', '\u0023', '\u0027', '\u002a', 
	'\u002b', '\u002d', '\u002e', '\u0030', '\u0039', '\u0041', '\u005a', '\u005e', 
	'\u007a', '\u0021', '\u003a', '\u004e', '\u006e', '\u007c', '\u007e', '\u0023', 
	'\u0027', '\u002a', '\u002b', '\u002d', '\u002e', '\u0030', '\u0039', '\u0041', 
	'\u005a', '\u005e', '\u007a', '\u0021', '\u003a', '\u0047', '\u0067', '\u007c', 
	'\u007e', '\u0023', '\u0027', '\u002a', '\u002b', '\u002d', '\u002e', '\u0030', 
	'\u0039', '\u0041', '\u005a', '\u005e', '\u007a', '\u0021', '\u003a', '\u0054', 
	'\u0074', '\u007c', '\u007e', '\u0023', '\u0027', '\u002a', '\u002b', '\u002d', 
	'\u002e', '\u0030', '\u0039', '\u0041', '\u005a', '\u005e', '\u007a', '\u0021', 
	'\u003a', '\u0048', '\u0068', '\u007c', '\u007e', '\u0023', '\u0027', '\u002a', 
	'\u002b', '\u002d', '\u002e', '\u0030', '\u0039', '\u0041', '\u005a', '\u005e', 
	'\u007a', '\u0021', '\u003a', '\u007c', '\u007e', '\u0023', '\u0027', '\u002a', 
	'\u002b', '\u002d', '\u002e', '\u0030', '\u0039', '\u0041', '\u005a', '\u005e', 
	'\u007a', '\u0020', '\u0020', '\u0020', '\u0023', '\u0020', '\u0023', '\u0020', 
	'\u0041', '\u005a', '\u0061', '\u007a', '\u0020', '\u0041', '\u005a', '\u0061', 
	'\u007a', '\u0020', '\u0041', '\u005a', '\u0061', '\u007a', '\u0020', '\u0041', 
	'\u005a', '\u0061', '\u007a', '\u0020', '\u0041', '\u005a', '\u0061', '\u007a', 
	'\u0020', '\u0041', '\u005a', '\u0061', '\u007a', '\u0020', '\u0041', '\u005a', 
	'\u0061', '\u007a', '\u0020', '\u0041', '\u005a', '\u0061', '\u007a', '\u0020', 
	'\u0041', '\u005a', '\u0061', '\u007a', '\u0020', '\u0041', '\u005a', '\u0061', 
	'\u007a', '\u0020', '\u0041', '\u005a', '\u0061', '\u007a', '\u0020', '\u0041', 
	'\u005a', '\u0061', '\u007a', '\u0020', '\u0041', '\u005a', '\u0061', '\u007a', 
	'\u0020', '\u0041', '\u005a', '\u0061', '\u007a', '\u0020', '\u0041', '\u005a', 
	'\u0061', '\u007a', '\u0020', '\u0041', '\u005a', '\u0061', '\u007a', '\u0020', 
	'\u0041', '\u005a', '\u0061', '\u007a', '\u0020', '\u0041', '\u005a', '\u0061', 
	'\u007a', '\u0020', '\u0041', '\u005a', '\u0061', '\u007a', '\u0020', '\u0041', 
	'\u005a', '\u0061', '\u007a', '\u0020', '\u0041', '\u005a', '\u0061', '\u007a', 
	'\u0020', '\u0041', '\u005a', '\u0061', '\u007a', '\u0020', (char) 0
};

static readonly sbyte[] _http_parser_single_lengths =  new sbyte [] {
	0, 0, 1, 3, 3, 1, 1, 1, 
	1, 1, 0, 1, 0, 1, 1, 6, 
	1, 4, 2, 1, 6, 6, 6, 6, 
	6, 6, 6, 6, 6, 6, 6, 6, 
	6, 4, 1, 1, 2, 2, 1, 1, 
	1, 1, 1, 1, 1, 1, 1, 1, 
	1, 1, 1, 1, 1, 1, 1, 1, 
	1, 1, 1, 1, 1, 0, 0
};

static readonly sbyte[] _http_parser_range_lengths =  new sbyte [] {
	0, 2, 2, 0, 0, 0, 0, 0, 
	0, 0, 1, 0, 1, 0, 0, 6, 
	0, 6, 0, 0, 6, 6, 6, 6, 
	6, 6, 5, 6, 6, 6, 6, 6, 
	6, 6, 0, 0, 0, 0, 2, 2, 
	2, 2, 2, 2, 2, 2, 2, 2, 
	2, 2, 2, 2, 2, 2, 2, 2, 
	2, 2, 2, 2, 0, 0, 0
};

static readonly short[] _http_parser_index_offsets =  new short [] {
	0, 0, 3, 7, 11, 15, 17, 19, 
	21, 23, 25, 27, 29, 31, 33, 35, 
	48, 50, 61, 64, 66, 79, 92, 105, 
	118, 131, 144, 156, 169, 182, 195, 208, 
	221, 234, 245, 247, 249, 252, 255, 259, 
	263, 267, 271, 275, 279, 283, 287, 291, 
	295, 299, 303, 307, 311, 315, 319, 323, 
	327, 331, 335, 339, 343, 345, 346
};

static readonly sbyte[] _http_parser_indicies =  new sbyte [] {
	0, 0, 1, 2, 3, 3, 1, 1, 
	1, 1, 4, 6, 7, 8, 5, 9, 
	1, 10, 1, 11, 1, 12, 1, 13, 
	1, 14, 1, 15, 1, 16, 1, 17, 
	1, 18, 1, 19, 20, 21, 21, 20, 
	20, 20, 20, 20, 20, 20, 20, 1, 
	22, 1, 23, 24, 23, 23, 23, 23, 
	23, 23, 23, 23, 1, 26, 26, 25, 
	28, 27, 23, 24, 29, 29, 23, 23, 
	23, 23, 23, 23, 23, 23, 1, 23, 
	24, 30, 30, 23, 23, 23, 23, 23, 
	23, 23, 23, 1, 23, 24, 31, 31, 
	23, 23, 23, 23, 23, 23, 23, 23, 
	1, 23, 24, 32, 32, 23, 23, 23, 
	23, 23, 23, 23, 23, 1, 23, 24, 
	33, 33, 23, 23, 23, 23, 23, 23, 
	23, 23, 1, 23, 24, 34, 34, 23, 
	23, 23, 23, 23, 23, 23, 23, 1, 
	23, 35, 23, 24, 23, 23, 23, 23, 
	23, 23, 23, 1, 23, 24, 36, 36, 
	23, 23, 23, 23, 23, 23, 23, 23, 
	1, 23, 24, 37, 37, 23, 23, 23, 
	23, 23, 23, 23, 23, 1, 23, 24, 
	38, 38, 23, 23, 23, 23, 23, 23, 
	23, 23, 1, 23, 24, 39, 39, 23, 
	23, 23, 23, 23, 23, 23, 23, 1, 
	23, 24, 40, 40, 23, 23, 23, 23, 
	23, 23, 23, 23, 1, 23, 24, 41, 
	41, 23, 23, 23, 23, 23, 23, 23, 
	23, 1, 23, 42, 23, 23, 23, 23, 
	23, 23, 23, 23, 1, 6, 43, 45, 
	44, 6, 7, 46, 48, 49, 47, 2, 
	50, 50, 1, 2, 51, 51, 1, 2, 
	52, 52, 1, 2, 53, 53, 1, 2, 
	54, 54, 1, 2, 55, 55, 1, 2, 
	56, 56, 1, 2, 57, 57, 1, 2, 
	58, 58, 1, 2, 59, 59, 1, 2, 
	60, 60, 1, 2, 61, 61, 1, 2, 
	62, 62, 1, 2, 63, 63, 1, 2, 
	64, 64, 1, 2, 65, 65, 1, 2, 
	66, 66, 1, 2, 67, 67, 1, 2, 
	68, 68, 1, 2, 69, 69, 1, 2, 
	70, 70, 1, 2, 71, 71, 1, 2, 
	1, 72, 73, 0
};

static readonly sbyte[] _http_parser_trans_targs =  new sbyte [] {
	2, 0, 3, 38, 4, 4, 5, 34, 
	36, 6, 7, 8, 9, 10, 11, 12, 
	13, 14, 15, 16, 17, 20, 61, 17, 
	18, 19, 18, 19, 14, 21, 22, 23, 
	24, 25, 26, 27, 28, 29, 30, 31, 
	32, 33, 18, 35, 35, 5, 37, 37, 
	5, 34, 39, 40, 41, 42, 43, 44, 
	45, 46, 47, 48, 49, 50, 51, 52, 
	53, 54, 55, 56, 57, 58, 59, 60, 
	62, 62
};

static readonly sbyte[] _http_parser_trans_actions =  new sbyte [] {
	1, 0, 5, 0, 7, 0, 11, 0, 
	0, 0, 0, 0, 0, 0, 19, 0, 
	21, 0, 0, 0, 23, 23, 0, 0, 
	25, 50, 0, 27, 29, 0, 0, 0, 
	0, 0, 0, 0, 0, 0, 0, 0, 
	0, 0, 47, 17, 0, 44, 13, 0, 
	38, 15, 0, 0, 0, 0, 0, 0, 
	0, 0, 0, 0, 0, 0, 0, 0, 
	0, 0, 0, 0, 0, 0, 0, 0, 
	53, 0
};

static readonly sbyte[] _http_parser_eof_actions =  new sbyte [] {
	0, 0, 3, 0, 9, 0, 0, 0, 
	0, 0, 0, 0, 0, 0, 0, 0, 
	0, 25, 0, 29, 25, 25, 25, 25, 
	25, 25, 25, 25, 25, 25, 25, 25, 
	25, 25, 9, 41, 9, 35, 3, 3, 
	3, 3, 3, 3, 3, 3, 3, 3, 
	3, 3, 3, 3, 3, 3, 3, 3, 
	3, 3, 3, 3, 3, 31, 33
};

const int http_parser_start = 1;
const int http_parser_first_final = 61;
const int http_parser_error = 0;

const int http_parser_en_main = 1;


#line 193 "HttpParser.cs.rl"
        
        public HttpParser(IHttpParserHandler parser)
        {
            this.parser = parser;
            
#line 237 "HttpParser.cs"
	{
	cs = http_parser_start;
	}

#line 198 "HttpParser.cs.rl"
        }

        public int Execute(ArraySegment<byte> buf)
        {
            byte[] data = buf.Array;
            int p = buf.Offset;
            int pe = buf.Offset + buf.Count;
            //int eof = pe == 0 ? 0 : -1;
            int eof = pe;
            mark = 0;
            qsMark = 0;
            fragMark = 0;
            
            
#line 257 "HttpParser.cs"
	{
	sbyte _klen;
	short _trans;
	sbyte _acts;
	sbyte _nacts;
	short _keys;

	if ( p == pe )
		goto _test_eof;
	if ( cs == 0 )
		goto _out;
_resume:
	_keys = _http_parser_key_offsets[cs];
	_trans = (short)_http_parser_index_offsets[cs];

	_klen = _http_parser_single_lengths[cs];
	if ( _klen > 0 ) {
		short _lower = _keys;
		short _mid;
		short _upper = (short) (_keys + _klen - 1);
		while (true) {
			if ( _upper < _lower )
				break;

			_mid = (short) (_lower + ((_upper-_lower) >> 1));
			if ( data[p] < _http_parser_trans_keys[_mid] )
				_upper = (short) (_mid - 1);
			else if ( data[p] > _http_parser_trans_keys[_mid] )
				_lower = (short) (_mid + 1);
			else {
				_trans += (short) (_mid - _keys);
				goto _match;
			}
		}
		_keys += (short) _klen;
		_trans += (short) _klen;
	}

	_klen = _http_parser_range_lengths[cs];
	if ( _klen > 0 ) {
		short _lower = _keys;
		short _mid;
		short _upper = (short) (_keys + (_klen<<1) - 2);
		while (true) {
			if ( _upper < _lower )
				break;

			_mid = (short) (_lower + (((_upper-_lower) >> 1) & ~1));
			if ( data[p] < _http_parser_trans_keys[_mid] )
				_upper = (short) (_mid - 2);
			else if ( data[p] > _http_parser_trans_keys[_mid+1] )
				_lower = (short) (_mid + 2);
			else {
				_trans += (short)((_mid - _keys)>>1);
				goto _match;
			}
		}
		_trans += (short) _klen;
	}

_match:
	_trans = (short)_http_parser_indicies[_trans];
	cs = _http_parser_trans_targs[_trans];

	if ( _http_parser_trans_actions[_trans] == 0 )
		goto _again;

	_acts = _http_parser_trans_actions[_trans];
	_nacts = _http_parser_actions[_acts++];
	while ( _nacts-- > 0 )
	{
		switch ( _http_parser_actions[_acts++] )
		{
	case 0:
#line 37 "HttpParser.cs.rl"
	{
            mark = p;
        }
	break;
	case 2:
#line 46 "HttpParser.cs.rl"
	{
            //Console.WriteLine("leave_method fpc " + fpc + " mark " + mark);
            parser.OnMethod(new ArraySegment<byte>(data, mark, p - mark));
        }
	break;
	case 3:
#line 51 "HttpParser.cs.rl"
	{
            //Console.WriteLine("enter_request_uri fpc " + fpc);
            mark = p;
        }
	break;
	case 5:
#line 61 "HttpParser.cs.rl"
	{
            //Console.WriteLine("leave_request_uri fpc " + fpc + " mark " + mark);
            parser.OnRequestUri(new ArraySegment<byte>(data, mark, p - mark));
        }
	break;
	case 6:
#line 66 "HttpParser.cs.rl"
	{
            //Console.WriteLine("enter_query_string fpc " + fpc);
            qsMark = p;
        }
	break;
	case 7:
#line 71 "HttpParser.cs.rl"
	{
            //Console.WriteLine("leave_query_string fpc " + fpc + " qsMark " + qsMark);
            parser.OnQueryString(new ArraySegment<byte>(data, qsMark, p - qsMark));
        }
	break;
	case 8:
#line 75 "HttpParser.cs.rl"
	{
            //Console.WriteLine("enter_fragment fpc " + fpc);
            fragMark = p;
        }
	break;
	case 9:
#line 80 "HttpParser.cs.rl"
	{
            //Console.WriteLine("leave_fragment fpc " + fpc + " fragMark " + fragMark);
            parser.OnFragment(new ArraySegment<byte>(data, fragMark, p - fragMark));
        }
	break;
	case 10:
#line 85 "HttpParser.cs.rl"
	{
			parser.OnVersionMajor((char)data[p] - '0');
		}
	break;
	case 11:
#line 104 "HttpParser.cs.rl"
	{
			parser.OnVersionMinor((char)data[p] - '0');
		}
	break;
	case 12:
#line 123 "HttpParser.cs.rl"
	{
            //Console.WriteLine("enter_header_name fpc " + fpc + " fc " + (char)fc);
            mark = p;
        }
	break;
	case 13:
#line 128 "HttpParser.cs.rl"
	{
            //Console.WriteLine("leave_header_name fpc " + fpc + " fc " + (char)fc);
            parser.OnHeaderName(new ArraySegment<byte>(data, mark, p - mark));
        }
	break;
	case 14:
#line 133 "HttpParser.cs.rl"
	{
            if (gotContentLength) throw new Exception("Already got Content-Length. Possible attack?");
            gotContentLength = true;
        }
	break;
	case 15:
#line 138 "HttpParser.cs.rl"
	{
            //Console.WriteLine("enter_header_value fpc " + fpc + " fc " + (char)fc);
            mark = p;
        }
	break;
	case 16:
#line 143 "HttpParser.cs.rl"
	{
            //Console.WriteLine("header_value_char fpc " + fpc + " fc " + (char)fc);
            if (gotContentLength)
            {
                var cfc = (char)data[p];
                if (cfc == ' ')
                {
                    {p++; if (true) goto _out; }
                }

                if (cfc < '0' || cfc > '9')
                    throw new Exception("Bogus content length");

                contentLength *= 10;
                contentLength += (int)data[p] - (int)'0';
            }
        }
	break;
	case 17:
#line 161 "HttpParser.cs.rl"
	{
            //Console.WriteLine("leave_header_value fpc " + fpc + " fc " + (char)fc);
            parser.OnHeaderValue(new ArraySegment<byte>(data, mark, p - mark));
        }
	break;
	case 18:
#line 166 "HttpParser.cs.rl"
	{
            parser.OnHeadersEnd();
        }
	break;
	case 19:
#line 170 "HttpParser.cs.rl"
	{
            //Console.WriteLine("enter_body fpc " + fpc);
            mark = p;
        }
	break;
#line 466 "HttpParser.cs"
		default: break;
		}
	}

_again:
	if ( cs == 0 )
		goto _out;
	if ( ++p != pe )
		goto _resume;
	_test_eof: {}
	if ( p == eof )
	{
	sbyte __acts = _http_parser_eof_actions[cs];
	sbyte __nacts = _http_parser_actions[__acts++];
	while ( __nacts-- > 0 ) {
		switch ( _http_parser_actions[__acts++] ) {
	case 1:
#line 41 "HttpParser.cs.rl"
	{
            //Console.WriteLine("eof_leave_method fpc " + fpc + " mark " + mark);
            parser.OnMethod(new ArraySegment<byte>(data, mark, p - mark));
        }
	break;
	case 4:
#line 56 "HttpParser.cs.rl"
	{
            //Console.WriteLine("eof_leave_request_uri!! fpc " + fpc + " mark " + mark);
            parser.OnRequestUri(new ArraySegment<byte>(data, mark, p - mark));
        }
	break;
	case 7:
#line 71 "HttpParser.cs.rl"
	{
            //Console.WriteLine("leave_query_string fpc " + fpc + " qsMark " + qsMark);
            parser.OnQueryString(new ArraySegment<byte>(data, qsMark, p - qsMark));
        }
	break;
	case 9:
#line 80 "HttpParser.cs.rl"
	{
            //Console.WriteLine("leave_fragment fpc " + fpc + " fragMark " + fragMark);
            parser.OnFragment(new ArraySegment<byte>(data, fragMark, p - fragMark));
        }
	break;
	case 13:
#line 128 "HttpParser.cs.rl"
	{
            //Console.WriteLine("leave_header_name fpc " + fpc + " fc " + (char)fc);
            parser.OnHeaderName(new ArraySegment<byte>(data, mark, p - mark));
        }
	break;
	case 17:
#line 161 "HttpParser.cs.rl"
	{
            //Console.WriteLine("leave_header_value fpc " + fpc + " fc " + (char)fc);
            parser.OnHeaderValue(new ArraySegment<byte>(data, mark, p - mark));
        }
	break;
	case 18:
#line 166 "HttpParser.cs.rl"
	{
            parser.OnHeadersEnd();
        }
	break;
	case 20:
#line 183 "HttpParser.cs.rl"
	{
            //Console.WriteLine("leave_body fpc " + fpc);
            parser.OnBody(new ArraySegment<byte>(data, mark, p - mark));
        }
	break;
#line 538 "HttpParser.cs"
		default: break;
		}
	}
	}

	_out: {}
	}

#line 212 "HttpParser.cs.rl"
            
            return p - buf.Offset;
        }
    }
}