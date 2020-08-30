using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace LeetCode.problems
{
    public class _336 : BaseClass
    {
        public override void Run()
        {
            var t = PalindromePairs(new string[] { "a", "abc", "aba", "" });
            t = PalindromePairs(new string[] { "abcd", "dcba", "lls", "s", "sssll" });
            var watch = Stopwatch.StartNew();
            t = PalindromePairs(new string[] { "egjc", "cffdegafjghcjbja", "ceaebcgaahfbdecff", "hfegaijc", "ccbggiabdjid", "fieffehfdjg", "dehb", "hefdiff", "dcfdeidifdiejhed", "igabjhdcigfe", "gjefahggjjjhaeebj", "fcidjgjg", "dbaeajjhdhiiegce", "iahjheggebhdhj", "ehbgfa", "ajgihafcgfbhab", "edji", "ajafhjigeiebadeighcb", "bhiiicde", "dfdaeahafjagadgb", "ibb", "fa", "fgidjeegeihjaa", "gifa", "jagdcd", "bhccdafgbbgfdd", "a", "ejajfjeibeijbg", "bfid", "igebffbahdaefgafj", "fghaceijhjfgjb", "iehaaddbcbb", "bicchgiabjjf", "ff", "abgicgaj", "fcbcab", "gihjjgcddg", "chgecbcddfiifcgjhjbg", "fe", "bgdjgcdhhgdjegeafbf", "fgifhhfbecbdgffcfha", "ejgdjiddhhahgbjbf", "dffie", "diefdghdfffaaj", "hdgfhibc", "fjfedcjiddhehjfg", "hdafgbabheeeaijffdd", "accc", "jgiidcd", "fidfiafd", "iecjbe", "edijc", "eeffhffcggcigjgaj", "ehbjhjhebbfhfeecb", "bige", "dgg", "hdhdhdbbdbaahe", "jhcebefcdcaigcbcc", "ccbjdebj", "da", "aidfjbjif", "jjdgg", "gieaffifdecde", "gejbhechchbbjfeddh", "acdgjecbjbf", "gedggabecabhb", "iffjfaijchfii", "hjhhehjaiich", "ejaggcbceeiia", "ihac", "adcafbdhaefag", "ifbggihdcacgjbficdaa", "jaajafi", "ge", "eggacaegea", "ghghhajcdhhgccjbb", "jiheh", "jgcfaabahhadjgcebj", "affaejidjd", "bbjadijhfeaaiif", "gafebchegbcbadh", "jbdcdcbaggc", "jaidajihdaiechb", "jefighiageiegeeeacib", "icfdcagdjggdhf", "g", "bfjeg", "adaaaebhf", "ceicfddafdge", "hjffjgdjaafjjbabccde", "jdhegebcehfbadficgaj", "ijafbedjbfieagcb", "hcjjj", "ghadbefeddbdfdih", "ajebdc", "bjf", "gijebdjddcjahjheaej", "jfb", "eajafjhbiifbjfhgjbie", "aaeeedbdiieedchffej", "gfbbijjageiajf", "dbcdhdbiai", "gdiaebahiabgcejehgjb", "eabaeh", "aeihfeedidcjhadejjc", "jibbi", "ihfhdfjedhjbacdiihfi", "ajadhiaeacgd", "iaajbjhjccbbbeieifd", "cbc", "cdi", "fijfchdbjihiifbj", "dagdfhhjfiffe", "jf", "iib", "i", "hbfdcfhaehcc", "cefjaicig", "f", "eacdhcfb", "gchdcdedf", "chiifjbhhcjeghbegi", "aijb", "ciaccb", "hdcgidfbbc", "hhcibaedbhheagcgcg", "d", "adhiggbfahecjabcgj", "cjbbcfhabhhiihddedgi", "gfcbgfegghigbaac", "b", "fajgfj", "dgaaj", "h", "fadbbhehhh", "fbdddccaajicjaaijafc", "ccbbcgecc", "ieahdccchcjccc", "cegfhdghjijdfg", "gefadijfahfgc", "eib", "fbajfadgcfgbahh", "gb", "afchde", "ijhcfdhiegfbeheg", "ahhgabfgeagcefajjh", "adjdjf", "bhhadgeejefdjdajb", "jadbhj", "ihecababjbddjcc", "ijihegfagcggicf", "bibgcefjabbce", "bfifeadbcfgfb", "ggafhi", "gbegbcaafeaeiabdbhid", "ihcfbhdciiibhai", "ibjbaaacgibghhgbejej", "bbd", "aecgdgfjcg", "dfcjdciajfchccffgghg", "ijhgjjg", "dcehcdhdficgjh", "fiecjad", "fg", "dahhgc", "bhghaciebichfa", "jjafigeffijhgedeh", "ffdeigj", "fcehjbdehjdi", "diefhafciba", "bdbib", "ichdhicibfgbebfabe", "ehfhedbeieibiicfb", "dahchfdbihffee", "fhhbjj", "ihcii", "iheefbjjcc", "cgdhgc", "bhjffggccdgifdfbff", "ecijfc", "caieahbibhegjhh", "edh", "cfbebgiffffgbbd", "bbghfdcbacjd", "ffahccfhfbcjbbdh", "jci", "ddiebhffhabab", "jhhdijjhgbbjbhjjd", "dag", "ifjeajajigfedeecjae", "fd", "fjhjjigicdajegfiea", "hiicfjbjgbbhfg", "adfegdiaab", "fdhhcg", "abid", "fhac", "ijdcaijiiaadgfigd", "beibcifegcj", "egbhajafe", "bjbfgbfidjhidadgggh", "efiehifgiaafcbfgabf", "jgjcjhfghcghdbidcd", "cbejgbifbcajijf", "eebacaiigbjh", "cfaihhhjgffiebh", "bibfcajaaifacifib", "ade", "diabfdbebdccffbdeg", "eiie", "bfdacefhih", "jhigecid", "dijjhijeghjgaii", "giff", "ee", "fc", "ihiaabfbahfehddcgf", "cibc", "beib", "jg", "ibd", "cb", "gj", "hhgfjcgjcgeaghhidi", "fefjghfahgafgajh", "aaedbaefdje", "jiad", "cidhdedghdhgccg", "ehigegjicf", "chjdjjdbgjbiefhcd", "jjfgedcjefhjhb", "gdbfhjfebcii", "cfecc", "iijhdiifhcabeccdgh", "dcdeacij", "hjihhche", "hjagdhbi", "ehahfj", "cjebecccffi", "gbj", "gfechha", "bhjajgibffh", "dc", "bde", "djjeagi", "ibchbgh", "cgh", "feghbh", "cif", "aggeggbbgjjf", "cbjcfbebjjfgjacieb", "ehhfhij", "bbabddbgeif", "fejhiijdbigdjhaiigf", "jfbgcfcigcccfecfjhfe", "cgahgcegcaacc", "fhaijdcachd", "jjebjibhf", "bgciaigi", "efeiabfiajge", "bagdf", "ca", "jbhfg", "dejjfdghaiid", "ghbjhcadhhjeed", "fha", "ehhdjd", "ea", "eifidbdbffichjba", "bddhcjebijfige", "hgejibccjhchcbccadg", "c", "j", "agbd", "fgdgjhgagijbhcbhbce", "ci", "fdc", "ddhhgfebbbaicb", "hhdhjfieccacab", "iceciidjb", "gcjjabfi", "bajbghgiibjhbjjegihi", "gbicaaffcidahhje", "ihcgdcfaegbcdifa", "bcbfcgjccfhhchjba", "jbajia", "eie", "icgbgjjfeifciji", "fcacccdcfcghdgbdjc", "eef", "dejdiafjiefdhififb", "chhfcgfcfe", "eeihjhia", "cafgaafjjjch", "bifjbai", "ichgfhbgbigih", "ebiaeeaedie", "cigeghgj", "ififjjfab", "cdbacffdceidcjfifaa", "iba", "e", "cjhcajejbbciff", "jaejhigdihbadgiehbhj", "gfgg", "jcchfejdhfagghabig", "efjjeadgiib", "cejaddhbajehfhjeh", "jjigbegiihbii", "eieedjhiffeibfhha", "efhhdejacjjaeii", "eaeahgahefea", "ebdedgifhfidigif", "hdhbbchj", "aijggibcdgiaecggfj", "cegiagb", "cdgecgej", "hfjfacg", "fchicjfffgjfcceed", "ddaedjaief", "iiggbefhafcjjeffgdae", "ice", "cefjgfgifehegfcichbb", "fgbajdjacicd", "cacd", "hedjahaiacgafh", "jhjjgjfdib", "ifccgbeefjbddhjhgbj", "iiahcdcieagi", "geaehefdeda", "bh", "aggdbhjaajbhgcehcafj", "bfhddeegjiihgfic", "dhabafiidja", "hafbiijiddfh", "fdiddcbcdjhchbfiagji", "aeeahjgcjfd", "fgiegaigjadefacab", "ejabjdgie", "cbegegaiecg", "igacehg", "djhddcdeejfejjh", "fj", "bechhehd", "adaghabfedeejad", "bbhjgdihjgjje", "jhghdjccdc", "abej", "hggagdbi", "dhagcbfibecjhjef", "igccifbjidf", "hdffacgbhdccjehgf", "hijfhhhcahdffei", "bhegeafhg", "fjfcf", "jdeigibgdijhhgbdd", "bfdhfdaiaga", "gcd", "haedfc", "hgif", "ghdcffgfiajaib", "geecee", "icejjhgdbgeb", "gibffgggajdac", "dejd", "aebfehccebefcegggag", "dbcfhicjhedjic", "ddbegjjdeeic", "cdhfahdidaag", "hcbijeabb", "aebfehgjdiegebif", "eceag", "fiegfgbhabgfgj", "gafcjf", "hgbi", "dfcgaifecfhbe", "ejacffd", "jea", "edifgjhhefihecjig", "hg", "fhccbhaeddefbc", "agaghdiieddcfdj", "jihdj", "jceccja", "iddecfadaghhbabccja", "iiidgb", "ji", "cefadjfhdd", "aaibigigbibgihajiif", "fcfchc", "jihegbhgj", "bcfdjiieaccdhjfhef", "jcigja", "fehfbfgjci", "aajbejf", "jeedcebaifbcfdiahc", "hchfgicah", "fdjhefbcifj", "hjaghebhi", "hdg", "acdj", "gbfjifdgfeg", "bdjcjdagabfafg", "ifiedgah", "acaffebaaiafjhibjh", "gaajc", "eceieefhgaahcidbei", "agaaaacediadjchhbbi", "gcdhjgabheighbcie", "ccjhd", "hd", "ahjhgjibafa", "dcfbjfi", "edigfjhageccada", "afh", "chgjhhfjddcf", "bebeaaaa", "fjagaibhegcfiggfhbja", "acjdgjeechfbeheea", "ebjfbeef", "cfeich", "bbdehadg", "gaeahafcideaciccei", "dbaehaedeagfhf", "ifhcficfih", "ddhigagiiibcechhg", "hdegjbbeeeefhgccc", "fibchhcaeic", "dcifgafdceej", "bch", "baadcie", "afiahiddiajdhjga", "heigcjdbji", "dgdjhijgbfaffgfg", "jcabeibghdedeffjad", "gc", "iibfejceee", "jejghhcbih", "geegbdibgghgedgib", "edijjigahebgehefbjg", "chbeaiadicbdfhijf", "cifjjdgjiaigj", "ihbcbhhjbeghgbieh", "bejfffdcjaghigdcgi", "bijech", "jiahegbedaedabhibddi", "beaaddhijcc", "hf", "iechejicafifgabcfcje", "cecbgjjhhj", "baeaigegdedi", "fbhaaibbeegehhahdg", "ejjgaggficabia", "jciahfjhb", "efjejhdfhajh", "gbfabejcifgibf", "cfehigahg", "ifdh", "cffhcdeddjdddbbefeci", "fdhfbghicefabahggich", "gdhhijgfg", "jgjehcfbdcj", "ihgdadahghaahjhcefj", "jj", "gjdehiacafdjigd", "aigefeihaff", "jfdigggjbjegbbibiea", "dbhehijieace", "bfjhejejihchiijfe", "cjiaccajjc", "aeaddjfafbchb", "gjcdccibddggafcjdcc", "gd", "gehgaecdefcjhjfdihe", "ajhhegjeghegffaadgbi", "jjgiicjigbdhbaj", "faefebb", "bhai", "cdggcgfcegegd", "gfefabcdehiddfdidgcf", "bjdfhcggi", "dhch", "ebgcaieajaia", "bfgdieddiddha", "dcgdhjea", "gh", "figfa", "giddhcjhgcghcdac", "defgehccjgfcbhi", "hgdeffigfadae", "gddd", "idihb", "aggbjice", "hdcigdcc", "acecehfhgbecababbf", "eeddhhfhgbiceae", "deeghci", "adghecej", "hhaicfcebgfjehggced", "caghc", "bdddgbjdhgejigce", "dbgface", "hbd", "hchgehfgcjbhjg", "bijcbhdbjabhacbdgj", "aiaec", "fdaiaiahdje", "ahjeafc", "hefbdhgbcdiddgbbi", "dicbgdebeagii", "gjhfejbb", "eiicjjicijjba", "eheg", "dgcaihhg", "gehcaah", "ccc", "bgj", "fee", "cfji", "bgfgiacg", "gi", "giejjcgcai", "aihjccedfedgfie", "aca", "djei", "eahbihffejagiid", "jdefe", "hcfgii", "ejedeebcaaafffg", "fcb", "gbchafjb", "jheafdcfg", "bfgbjhchedfacgjjie", "hhdbii", "fjccjf", "acfbdfjcjjjbbg", "caiiicfhgeheifjii", "bbjcdciai", "aedfgbcbihddificjf", "iigda", "ggfifjdccegbjjdd", "idcbej", "bcabdgfgdbdh", "eeggacidificdefhb", "gdcgbibfddhgcc", "ibeddcicbgabi", "gchbeaga", "hcfaeabgedaiacaggi", "hjjeficf", "iaeafb", "cdgiegabih", "idcg", "ghafdidigjgjg", "bgceifebiefagj", "efabge", "bbaedbhjbccae", "hifccjjggd", "fbjjgdeficaiehhbg", "jegadfe", "afeefebjh", "hbjcchagiafacabfh", "diggjdiga", "fggcecedjacacbcda", "dbibfcbgfbj", "jee", "ccadgeecbgediddbdhh", "adihbbjgc", "bcjhadibdecebjfbhccg", "gghigahdfihidjbdgiea", "dfeeidajbija", "aichif", "iccgejac", "hfadb", "acaejjchiddab", "cbdbeagebadgjj", "abjajcih", "hfbc", "df", "ibihejfdajgccjhab", "ebhc", "hbhagdbchigff", "dabehffgfcj", "aa", "bgafagdbig", "ajchgjgehbgceegj", "hichefadd", "hdejfdiefeecighdidi", "dcje", "ibjdihjddf", "cfjdgcfcggjcfjd", "badbbbhageihbg", "egaaggjjibjdcich", "cajbchadibefcaagefc", "ihbi", "iecbddjefh", "edchchiegbeb", "baaahddgcechjac", "caeighaibjcebah", "heg", "fcdeejdagcfbhgihhb", "gjhd", "ahgihcidehjjhhfed", "jjfj", "hghchfibffehbdefa", "bibjggff", "icjffiefbig", "aeegca", "ajdfjecb", "chc", "bg", "ahh", "cgbfg", "hdc", "bjgbfgcjcghced", "iegadbhedifigfgbagea", "edhge", "abbjidc", "fjhaghgjfg", "cahihieafjfgf", "hdfc", "jbbbfbdg", "ebbice", "becieafcaihcgiiiebac", "bfdcdjgafa", "ehdcdidedgegg", "dhfcadhdf", "efbgihicgjdcchaf", "che", "eb", "cjcebccccahhddfhbjfi", "cjgdjihdbacacfgj", "gdedefdbhfeid", "afc", "eccccdcfifccebagj", "gfijebhgjdadca", "dgdaa", "abedbgeiegfehcjg", "edadjefedcjg", "hggadjaefgehjfgcbci", "icfbijcccjigfddighdf", "dgfh", "dcceahcjebejcii", "deegefcdgbebe", "fiegafff", "cdcgcebhfc", "begbi", "cgajeeijdd", "hihbajigih", "dabdihagfic", "gcafchijdjiediecabbh", "dihj", "geecfabbbfagh", "eehdgebfcjbgefeai", "chdjjdijdi", "cchcafafjgcgaacaaf", "dcedjcgdfadibbba", "jjebffjfddaghfeggice", "fehjd", "ghgbjigchjfid", "jbicfhjhbebdecfcjb", "cbbadicachbdgedfcb", "adefbcagje", "jfbecdbad", "cffbjijeijgaed", "hdbgichhdihaji", "ej", "jeehjaec", "efbgccbjiiahgbjid", "jhdiaha", "biaie", "gciggdch", "fbbfaehebdcdjei", "fchehaiabie", "dd", "bggidgdcjigdhcdjighd", "gedabcfi", "dgdjah", "ijcae", "fcjcee", "ib", "ebbdebfbgefehajd", "chcbe", "adgbcjdi", "bf", "fiijeafiaiibeh", "edcfibjhcgdehcbibb", "efajiifbiejb", "fachigjeehajgh", "giffgefgbhhgacie", "ghfbafhcfgdajeic", "de", "cdejjeg", "ibadddc", "djfdej", "jbiegbc", "bifgg", "ggjfhbjeejdgd", "ahjiacafce", "ec", "eiijjiecdaefb", "aceccfdgejaibea", "ajee", "ichiaddgcdi", "eibh", "cedgiijigaecgiecfid", "dgdbb", "iifefibcddhjedah", "daffdgfi", "cieiffijd", "ebdedhdfdcggfgdgdi", "aeabhgdhfih", "cggebfabicifagddjcaj", "bgaheajfefbb", "dfccdbceaehihgdjb", "fhcaafg", "jffbbhgjjdcjcad", "ggaeeeiihbbjch", "jhfjg", "igjcgg", "cadee", "jiabjg", "bebbjabbehcfeb", "igjiicgjihcif", "gghgifcbeda", "jbbiijigf", "gjaei", "dbieiideh", "ibjid", "dgibcabejjigebjdgdfh", "edgeafgfbiehefgijde", "hhfiidjjdfehic", "egjjbibbbjia", "igjhhcbheabcbda", "ibfjjc", "ggc", "jbdhbb", "jjgdjcjdjhb", "ccjbdafdegfhhajjegjf", "hajdbcfjidj", "egjb", "dhg", "jhfghgb", "hhhjbeghfjehbibdg", "defceie", "ghjih", "hacacgafh", "ecaebfgdibbgfdchi", "hheeigehggjadf", "ddecbgbaadjjg", "bcjgf", "iceejeadicec", "eff", "eggafgfj", "fhfagajgbacddb", "cddfabh", "ibejijhjhidiggf", "eiejeedgadhfdfada", "ijgg", "bdjbggbddg", "hhiiff", "deb", "cbbcf", "iffijcicgdhebfd", "cfjfahceddbheijfbe", "iheedficaadghjgh", "ghgiijbeeffcfjfg", "gejififaia", "fjaejjdchdjcecbb", "efacgeebcbcaeb", "chibdggbd", "ch", "beha", "die", "icfacgjfjadde", "dcgjhaahdcehfge", "ha", "jag", "geaccfefghjhiacd", "efdefj", "eeiihfbadfhfeg", "jbgef", "eec", "jjicfjhcfhgabbdajjg", "hfefeffdhigbiaghi", "ijdidcbafbbe", "agedhdbdbbcfgadfdb", "jbiegcfefab", "jaa", "hiiabfaiggaghdffigc", "ibedffcae", "aiicaaijeafbdc", "fggijjdch", "aajcijb", "adejgaaeh", "hihddjgf", "db", "fiif", "bedbjeada", "jcafbibfjhfjjbi", "abficgcficcbhbc", "gghahecchecjad", "ba", "higidbbeaac", "egheabaichadfbafd", "bbjbgbdcgadjjf", "bhdbjgceehceghaice", "jhebfdgbhiehfb", "jghg", "edc", "afhebjajhe", "dg", "fggfeb", "cbac", "gff", "bhiahigjihfigeige", "abjhgg", "afhgg", "dfdafbc", "dfe", "ijgghfgbhbjhdidghgjg" });
            watch.Stop();
            Console.WriteLine(watch.ElapsedMilliseconds + "");
        }

        public IList<IList<int>> PalindromePairs(string[] words)
        {
            var ansList = new List<IList<int>>();
            for (int i = 0; i < words.Length; i++)
                for (int j = 0; j < words.Length; j++)
                {
                    if (i == j)
                        continue;
                    if (IsHw(words[i], words[j]))
                        ansList.Add(new int[] { i, j });
                }
            return ansList;
        }
        private bool IsHw(string word1, string word2)
        {
            var len = word1.Length + word2.Length;
            var cnt = len >> 1;

            for (int i = 0, right = word2.Length; i < cnt; i++)
            {
                --right;
                if (i >= word1.Length)
                {
                    if (word2[i - word1.Length] != word2[right])
                        return false;
                }
                else if (i >= word2.Length)
                {
                    if (word1[i] != word1[len - i - 1])
                        return false;
                }
                else if (word1[i] != word2[right])
                    return false;
            }
            return true;
        }

        private bool IsHw2(string word1, string word2)
        {
            var word = word1 + word2;
            int right = word.Length;
            int cnt = right >> 1;
            for (int i = 0; i < cnt; i++)
            {
                if (word[i] != word[--right])
                    return false;
            }
            return true;
        }
        int group;
        string word;
        List<IList<int>> ansList;
        List<int> matchList;
        public IList<IList<int>> PalindromePairs2(string[] words)
        {
            ansList = new List<IList<int>>();
            var root = new TreeNode();
            var rootRev = new TreeNode();
            for (group = 0; group < words.Length; group++)
            {
                word = words[group];
                BuildTrie(0, root);
                BuildTrie(word.Length - 1, rootRev, -1);
            }

            dfs(root, rootRev);

            return ansList.Where(item => item[0] != item[1]).ToArray();
        }

        public void dfs(TreeNode node1, TreeNode node2)
        {
            if (node1.Val != node2.Val)
                return;
            if (node1.IsEnd || node2.IsEnd)
            {
                matchList = new List<int>();
                if (!node1.IsEnd)
                {
                    dfs(node1);
                    ansList.AddRange(matchList.Select(matchIdx => new int[] { matchIdx, node2.WordGroup }));
                }
                else if (!node2.IsEnd)
                {
                    dfs(node2);
                    ansList.AddRange(matchList.Select(matchIdx => new int[] { node1.WordGroup, matchIdx }));
                }
                else
                    ansList.Add(new int[] { node1.WordGroup, node2.WordGroup });
            }

            foreach(var kv in node1.Children)
            {
                var childNode1 = kv.Value;
                if (!node2.Children.TryGetValue(kv.Key, out TreeNode childNode2))
                    continue;

                dfs(childNode1, childNode2);
            }
        }

        public int dfs(TreeNode node)
        {
            return 0;
        }

        public void BuildTrie(int idx, TreeNode parentNode, int jw = 1)
        {
            if (!parentNode.Children.TryGetValue(word[idx], out TreeNode childNode))
            {
                childNode = new TreeNode(word[idx]);
                parentNode.Children.Add(word[idx], childNode);
            }

            if (idx == (jw == 1 ? word.Length - 1 : 0))
            {
                childNode.IsEnd = true;
                childNode.WordGroup = group;
            }
            else
                BuildTrie(idx + jw, childNode, jw);
        }

        public class TreeNode
        {
            public Dictionary<char, TreeNode> Children { get; set; }
            public char Val { get; set; }
            public bool IsEnd { get; set; }
            public int WordGroup { get; set; }

            public TreeNode(char val = ' ')
            {
                Val = val;
                Children = new Dictionary<char, TreeNode>();
            }

            public override string ToString()
            {
                return Val + " " + "count: " + Children.Count;
            }
        }
    }
}
