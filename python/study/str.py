import random

name = ['홍길동','희동이','둘리']
eng_name = {
    '홍길동':'hong',
    '희동이':'dhng',
    '둘리':'twelee'
}

지목된사람 = random.choice(name)
지목된영어사람 = eng_name[지목된사람]

intro ='저는' + 지목된사람 + '입니다.' + 'my name is ' + 지목된영어사람

print(intro)