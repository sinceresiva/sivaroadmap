import { CQAssuredWebPage } from './app.po';

describe('cqassured-web App', function() {
  let page: CQAssuredWebPage;

  beforeEach(() => {
    page = new CQAssuredWebPage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
