import requests
import bs4

html = requests.get('https://www.naver.com/')
soup = bs4.BeautifulSoup(html.text,"html.parser")

keywords = soup.select('span.ah_k')

#for keyword in keywords:
#    print(keyword.text)

cutkeyword = keywords[0:20]
real_keywords = [keyword.text for keyword in cutkeyword]
for i in range(10):
    problum = sorted(real_keywords)

print(real_keywords)
print(problum)
answer = input('당신이 입력한 답:')
if answer == real_keywords[0]:
    print('덩잡')
else:
    print('오답')
