from selenium import webdriver
from selenium.webdriver.common.keys import Keys
path = './chromedriver.exe'

driver = webdriver.Chrome(path)
driver.get("https://nid.naver.com/nidlogin.login?url=http%3A%2F%2Fmail.naver.com%2F")
#driver.get('https://www.google.com/')

search_input =driver.find_element_by_css_selector('#frmNIDLogin > fieldset > div.id_area')
search_input.send_keys('lovekwag')
#frmNIDLogin > fieldset > div.pw_area

#search_input =driver.find_element_by_css_selector('#frmNIDLogin > fieldset > div.pw_area')
#search_input.send_keys('c67dd43as!')

#search_input =driver.find_element_by_css_selector('#frmNIDLogin > fieldset > input')
#search_input.send_keys('hello world\n')
#search_input.send_keys(Keys.RETURN)

#edubing