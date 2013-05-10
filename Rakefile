require 'webrick'
require 'rake/clean'
require 'rexml/document'

HAML = FileList.new('*.haml')
HTML = HAML.ext('html')
SCSS = FileList.new('*.scss')
CSS = SCSS.ext('css')
LAYOUT = HTML + CSS

CLEAN.include(LAYOUT)

rule '.html' => ['.haml'] do |t|
    sh %{ haml -E utf-8 #{t.source} #{t.name} }
end

rule '.css' => ['.scss'] do |t|
    sh %{ sass -t compressed #{t.source} #{t.name} }
end

desc 'Generate html and css from sources'
task :default => LAYOUT do
end

desc 'Start a webserver to serve this presentation'
task :serve => :default do
    server = WEBrick::HTTPServer.new :Port => 4000, :DocumentRoot => __dir__
    trap 'INT' do server.shutdown end
    server.start
end
