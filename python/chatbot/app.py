from flask import Flask,request
import requests
from decouple import config
import random

app = Flask(__name__)

@app.route('/')
def hello():
    return 'hello world'

api_url= 'https://api.telegram.org'
naver_url = "https://openapi.naver.com/v1/papago/n2mt"
headers ={
    'Content-Type':'application/x-www-form-urlencoded; charset=UTF-8',
    'X-Naver-Client-Id': '3mS3_XccDGBB53PH9KlI', 
    'X-Naver-Client-Secret': 'Sn4LJrz5s3' 
}

token = config('TOKEN')
chat_id = config('CHAT_ID')

naver_client_id =config('CLIENT_ID')
naver_client_id = config('CLIENT_SECRET')

@app.route('/send/<text>')
def send(text):
    requests.get(f'{api_url}/bot{token}/sendMessage?chat_id={chat_id}&text={text}')
    return 'ok!'


@app.route('/chatbot',methods=['POST'])
def chatbot():
    #print(request.get_json())
    from_telegram = request.get_json()
    chat_id = from_telegram.get('message').get('from').get("id")
    get_massage = from_telegram.get('message').get('text')
    
    if get_massage=='메뉴':
        menus =['양자강','20층', '김밥카페']
        lunch = random.choice(menus)
        respons =lunch
    elif get_massage=='로또':
        lotto = random.sample(range(1,46),6)
        lotto = sorted(lotto)
        respons = f'추천 번호는 {lotto}입니다'
    elif get_massage[0:3] == '번역 ':
        text = get_massage[3:]
        data =f'source=ko&target=en&text={text}'.encode('utf-8')
        get_respons = requests.post(url=naver_url,headers=headers,data=data).json()
        respons = get_respons.get('message').get('result').get('translatedText')
    else:
        respons = f'너는 {get_massage}라고 보냈는데 무슨말인지 몰라'
    res = requests.get(f'{api_url}/bot{token}/sendMessage?chat_id={chat_id}&text={respons}')
    return 'ok',200
    #status code 200 -> ok! 잘 접수했다.


