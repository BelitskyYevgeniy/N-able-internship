function validateAndFormatCode(regexp, resultString, number) {
            let numberLength = number.length;
            let codes = [];
            if (resultString == '+375') codes = ['44', '29', '33', '25', '\\(44\\)', '\\(29\\)', '\\(33\\)', '\\(25\\)'];
            else
                codes = ['044', '029', '033', '025', '\\(044\\)', '\\(029\\)', '\\(033\\)', '\\(025\\)'];
       
            
            for (let i = 0; i < codes.length; ++i) {
                let reg = '^' + codes[i];
                regexp = new RegExp(reg);
                //console.log(regexp + " ---- " + reg + " ---- " + number);
                if (regexp.test(number)) {
                    let index = i % 4;
                    //console.log(resultString);
                    resultString += ' (' + codes[index].toString() + ') ';
                    //console.log(resultString + " ------ " + codes[index].toString() + " --------- "  + number);
                    number = number.substring(i > 3 ? codes[index].length + 2 : codes[index].length, numberLength);
                    //console.log(number + " ---- " + resultString);
                    return [number, resultString];
                }
            }
            return [number, resultString];
        }
        function formatPhoneNumber(number) {
            let regexp = /^8/;
            let result = '';
            if (/*regexp.test(number)*/number[0]=='8') {
                result = '8';
                number = number.substring(1);
                //console.log(result);
            }
            else {
                regexp = /^\+375/;
                if (regexp.test(number)) {

                    result = '+375';
                    number = number.substring(4);
                    //console.log(result + " ----- " + number);
                }
            }
            let validateCodeResult = validateAndFormatCode(regexp, result, number);
            if (validateCodeResult == null) {
                return null;
            }
            number = validateCodeResult[0];
            result = validateCodeResult[1];
            
            //console.log(number + " " + number.length);
            if (!(number.length == 7 || number.length == 9)) {
                return null;
            }


            let blocks = number.split('-');
            //console.log(blocks);
            if (!(blocks.length == 1 || blocks.length == 3))
                return null;
            let iterator = 0;
            
            for (let block of blocks) {
                for (let c of block) {
                    if (isNaN(parseInt(c))) {
                        return false;
                    }
                    result += c;
                    ++iterator;
                    if (iterator == 3 || iterator == 5) {
                        result += '-';
                    }
                }

            }               
            return result;
        }
        var regexp_ = /^(((\+375|80|0)(44|29|33|25|\(44\)|\(29\)|\(33\)|\(25\)))|(8?\(0(44|29|33|25)\)))?((\d{7})|(\d{3}(-\d{2}){2})|((\d{2}-){2}\d{3})|(\d{7}))$/;
        var test = ['sfdgsdfg', '80296758990', '+375296758990', '+375(29)6758990', '(029)675-89-90', '+375(29)675-89-90', '675-89-90', '6758990', '-375296758990', '+375t296758990', '+375(29]6758990', '-375296758990', '802967589901'];
        for (let i of test) {
            console.log(i + ": " + regexp_.test(i));
        }
        console.log('-------------------------------------');
        for (let i of test) {
            console.log(i + ": " + formatPhoneNumber(i));
        }