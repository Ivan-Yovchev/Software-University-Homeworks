'use strict';

function fixCasing(str) {

    var result = '';

    for (var i = 0; i < str.length; i++) {

        //change word to uppercase and remove tag
        if (str.charAt(i) == '<' && str.charAt(i + 1) == 'u') {
            
            var word = '';
            var end;

            for (var j = i + 8; j < str.length; j++) {

                if (str.charAt(j) == '<') {
                    word = word.toUpperCase();
                    end = j;
                    break;
                }

                word += str.charAt(j);

            }

            str = str.slice(0, i).concat(word).concat(str.slice(end + 9, str.length));

        }
        //change word to lowcase and remove tag
        else if (str.charAt(i) == '<' && str.charAt(i + 1) == 'l') {

            var word = '';
            var end;

            for (var j = i + 9; j < str.length; j++) {

                if (str.charAt(j) == '<') {
                    word = word.toLowerCase();
                    end = j;
                    break;
                }

                word += str.charAt(j);

            }

            str = str.slice(0, i).concat(word).concat(str.slice(end + 10, str.length));

        }
        //change word to mixcase and remove tag
        else if (str.charAt(i) == '<' && str.charAt(i + 1) == 'm') {

            var word = '';
            var end;

            for (var j = i + 9; j < str.length; j++) {

                if (str.charAt(j) == '<') {
                    
                    var newWord = '';

                    for (var index = 0; index < word.length; index++) {

                        var random = Math.random().toFixed(1);

                        if (random >= 0.5) {
                            newWord += word.charAt(index).toUpperCase();
                        }
                        else if (random < 0.5) {
                            newWord += word.charAt(index).toLowerCase();
                        }

                    }

                    word = newWord;

                    end = j;
                    break;
                }

                word += str.charAt(j);

            }

            str = str.slice(0, i).concat(word).concat(str.slice(end + 10, str.length));

        }

    }

    console.log(str);

}

fixCasing('We are <mixcase>living</mixcase> in a <upcase>yellow submarine</upcase>. We <mixcase>don\'t</mixcase> have <lowcase>anything</lowcase> else.');