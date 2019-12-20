import requests
import bs4

#이 주소로 요청을 보내면 응답으로 html 파일이 도착할 것
html = requests.get('https://finance.naver.com/marketindex/')
#html text를 내가 보기 좋게 접근할 수 있도록 변경!
soup = bs4.BeautifulSoup(html.text, 'html.parser')
#now_value

kospi = soup.select_one('#exchangeList > li.on')

print(kospi.text)
#now_value